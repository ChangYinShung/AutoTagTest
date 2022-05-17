using EasyAbp.EShop.Orders.Orders;
using EasyAbp.EShop.Orders.Orders.Dtos;
using EasyAbp.EShop.Products.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;

namespace CFTA.Orders
{
    public class CFTAOrderExtraFeeProvider : Volo.Abp.DependencyInjection.ITransientDependency, IOrderExtraFeeProvider
    {
        private readonly EasyAbp.EShop.Products.Products.IProductRepository ProductRepository;

        public CFTAOrderExtraFeeProvider(
            EasyAbp.EShop.Products.Products.IProductRepository ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }

        public async Task<List<OrderExtraFeeInfoModel>> GetListAsync(Guid customerUserId, CreateOrderDto input, Dictionary<Guid, ProductDto> productDict)
        {
            var result = new List<OrderExtraFeeInfoModel>();
            result.Add(this.addShoppingFee(input));
            result.AddRange(await this.addBackNumberFeeAsync(input));

            result = result
                .Where(x => x.Fee > 0)
                .ToList();

            return result;
        }


        private OrderExtraFeeInfoModel addShoppingFee(CreateOrderDto orderDto)
        {
            var contry = orderDto.ExtraProperties.ContainsKey("country") ?
                orderDto.ExtraProperties["country"] :
                "Taiwan";

            decimal fee = 0;
            switch (contry)
            {
                case "Taiwan":
                    fee = 0;
                    break;
                default:
                    fee = 200;
                    break;
            }

            return new OrderExtraFeeInfoModel("運費", "ShoppingFee", fee);
        }

        private async Task<List<OrderExtraFeeInfoModel>> addBackNumberFeeAsync(CreateOrderDto orderDto)
        {
            var productIds = orderDto.OrderLines.Select(x => x.ProductId).Distinct().ToList();
            var products = (await this.ProductRepository.GetQueryableAsync())
                .Where(x => productIds.Contains(x.Id))
                .ToList();

            var i = 0;
            var result = orderDto.OrderLines.Select(orderLine =>
            {
                i++;

                var product = products.Single(x => x.Id == orderLine.ProductId);

                var remark = orderLine.GetProperty<string>("remark");
                var extraFee = orderLine.GetProperty<decimal>("remarkExtraFee");
                var totalFee = orderLine.Quantity * extraFee;

                var extraFeeName = $"{product.DisplayName} ({remark})";

                return new OrderExtraFeeInfoModel(extraFeeName, $"RemarkExtraFee{i}", totalFee);
            }).ToList();

            return result;
        }
    }
}
