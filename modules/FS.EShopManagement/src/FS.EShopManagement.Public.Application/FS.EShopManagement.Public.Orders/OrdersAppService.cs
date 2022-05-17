using EasyAbp.EShop.Orders.Orders;
using FS.EShopManagement.Public.Orders.Dtos;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.Uow;
using EasyAbp.EShop.Stores.Stores;
using Volo.Abp.Domain.Repositories;
using EasyAbp.EShop.Orders.Authorization;
using Volo.Abp.ObjectExtending;

namespace FS.EShopManagement.Public.Orders
{



    public class OrdersAppService : MultiStoreReadOnlyAppService<
        Order,
        FS.EShopManagement.Public.Orders.Dtos.OrderDto,
        Guid,
        GetOrder>,
        IOrdersAppService
    {
        protected override string GetPolicyName { get; set; } = OrdersPermissions.Orders.Manage;
        protected override string GetListPolicyName { get; set; } = OrdersPermissions.Orders.Manage;
        protected override string CrossStorePolicyName { get; set; } = OrdersPermissions.Orders.CrossStore;

        private IOrderAppService ordersAppService => this.LazyServiceProvider.LazyGetRequiredService<IOrderAppService>();
        private EasyAbp.EShop.Payments.Payments.IPaymentAppService paymentAppService => this.LazyServiceProvider.LazyGetRequiredService<EasyAbp.EShop.Payments.Payments.IPaymentAppService>();
        private EasyAbp.PaymentService.Payments.IPaymentAppService paymentServiceAppService => this.LazyServiceProvider.LazyGetRequiredService<EasyAbp.PaymentService.Payments.IPaymentAppService>();

        private EasyAbp.PaymentService.Payments.IPaymentRepository paymentRepository => this.LazyServiceProvider.LazyGetRequiredService<EasyAbp.PaymentService.Payments.IPaymentRepository>();

        public OrdersAppService(IRepository<Order, Guid> repository) : base(repository)
        {
        }

        protected override async Task<IQueryable<Order>> CreateFilteredQueryAsync(GetOrder input)
        {

            var query = await base.CreateFilteredQueryAsync(input);
            //var filter = new FS.EShopManagement.Orders.UserOrderFilter() { CustomerUserId = input.CustomerUserId };
            return query.Where(x=>x.CustomerUserId  == input.CustomerUserId);
        }

        [UnitOfWork(IsDisabled = true)]
        public virtual async Task<EasyAbp.PaymentService.Payments.Dtos.PaymentDto> CreateOrderToPayAsync(CreateOrderToPayDto input)
        {
            // Create Order
            var orders = new List<EasyAbp.EShop.Orders.Orders.Dtos.OrderDto>();
            foreach(var item in input.CreateOrders)
            {
                var order = await this.ordersAppService.CreateAsync(item);
                orders.Add(order);
            }

            // Create Payment
            var paymentNo = DateTime.Now.ToString("yyyyMMddhhmmss");
            var paymentCreate = new EasyAbp.EShop.Payments.Payments.Dtos.CreatePaymentDto()
            {
                PaymentMethod = input.PaymentMethod,
                OrderIds = orders.Select(x => x.Id).ToList()
            };
            paymentCreate.SetProperty("PaymentNo", paymentNo);
            if (input.PaymentProperties != null)
                input.PaymentProperties.MapExtraPropertiesTo(paymentCreate, MappingPropertyDefinitionChecks.Destination);

            await this.paymentAppService.CreateAsync(paymentCreate);

            // Payment Pay
            // 每一個 Order 的 PaymentId 應皆一致
            var paymentOrder = await this.ordersAppService.GetAsync(orders.First().Id);
            var paymentToPayId = paymentOrder.PaymentId.Value;

            var payment = await this.paymentServiceAppService.PayAsync(
                paymentToPayId,
                new EasyAbp.PaymentService.Payments.Dtos.PayInput());


            var result = await this.paymentServiceAppService.GetAsync(payment.Id);
            return result;
        }
    }
}
