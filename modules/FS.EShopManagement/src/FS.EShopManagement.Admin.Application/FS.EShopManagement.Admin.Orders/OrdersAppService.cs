using EasyAbp.EShop.Orders.Authorization;
using EasyAbp.EShop.Orders.Orders;
using EasyAbp.EShop.Orders.Orders.Dtos;
using EasyAbp.EShop.Stores.Stores;
using FS.EShopManagement.Admin.Orders.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using EasyAbpOrders = EasyAbp.EShop.Orders.Orders;
using EasyAbpRefunds = EasyAbp.EShop.Payments.Refunds;

namespace FS.EShopManagement.Admin.Orders
{
    public class OrdersAppService : MultiStoreReadOnlyAppService<
        Order,
        FS.EShopManagement.Admin.Orders.Dtos.OrderDto,
        Guid,
        GetOrder>,
        FS.EShopManagement.Admin.Orders.IOrdersAppService
    {
        protected override string GetPolicyName { get; set; } = OrdersPermissions.Orders.Manage;
        protected override string GetListPolicyName { get; set; } = OrdersPermissions.Orders.Manage;
        protected override string CrossStorePolicyName { get; set; } = OrdersPermissions.Orders.CrossStore;

        private IOrderRepository _orderRepository => this.LazyServiceProvider.LazyGetRequiredService<IOrderRepository>();
        private EasyAbpOrders.IOrderAppService _easyAbpOrderAppService => this.LazyServiceProvider.LazyGetRequiredService<EasyAbpOrders.IOrderAppService>();
        private EasyAbpRefunds.IRefundAppService _easyAbpRefundAppService => this.LazyServiceProvider.LazyGetRequiredService<EasyAbpRefunds.IRefundAppService>();

        public OrdersAppService(IRepository<Order, Guid> repository) : base(repository)
        {
        }

        protected override async Task<IQueryable<Order>> CreateFilteredQueryAsync(GetOrder input)
        {
            var query = await base.CreateFilteredQueryAsync(input);

            var filter = new FS.EShopManagement.Orders.OrderFilter() { Filter=input.Filter };

            return filter.ApplyFilterTo(query);
        }

        public async Task OrderCompleteAndSetReceiptAsync(OrderCompleteAndSetReceipt input)
        {
            var order = await this._orderRepository.GetAsync(input.OrderId);

            order.SetProperty("receipt", input.Receipt);
            await this._orderRepository.UpdateAsync(order, true);

            await this._easyAbpOrderAppService.CompleteAsync(input.OrderId);
        }

        public async Task CancelOrderAsync(CancelOrder input)
        {
            var order = await this._easyAbpOrderAppService.GetAsync(input.OrderId);

            await this._easyAbpRefundAppService.CreateAsync(new EasyAbpRefunds.Dtos.CreateEShopRefundInput()
            {
                PaymentId = order.PaymentId.Value,
                DisplayReason = input.DisplayReason,
                StaffRemark = order.StaffRemark,
                CustomerRemark = order.CustomerRemark,
                RefundItems = new List<EasyAbpRefunds.Dtos.CreateEShopRefundItemInput>()
                {
                    new EasyAbpRefunds.Dtos.CreateEShopRefundItemInput()
                    {
                        OrderId = input.OrderId,
                        StaffRemark = order.StaffRemark,
                        CustomerRemark = order.CustomerRemark,
                        OrderLines = order.OrderLines.Select(x => new EasyAbpRefunds.OrderLineRefundInfoModel()
                        {
                            OrderLineId = x.Id,
                            Quantity = x.Quantity,
                            TotalAmount = x.ActualTotalPrice
                        }).ToList(),
                        OrderExtraFees = order.OrderExtraFees.Select(x =>
                        {
                            return new EasyAbpRefunds.OrderExtraFeeRefundInfoModel()
                            {
                                Name = x.Name,
                                Key = x.Key,
                                TotalAmount = x.Fee
                            };
                        }).ToList()
                    }
                }
            });
        }
    }
}
