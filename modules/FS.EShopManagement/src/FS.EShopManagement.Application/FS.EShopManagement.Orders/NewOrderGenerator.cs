using EasyAbp.EShop.Orders.Orders;
using EasyAbp.EShop.Products.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Timing;

namespace FS.EShopManagement.Orders
{
    [Volo.Abp.DependencyInjection.Dependency(ReplaceServices = true)]
    public class NewOrderGenerator : EasyAbp.EShop.Orders.Orders.NewOrderGenerator
    {
        public NewOrderGenerator(
            IClock clock,
            IGuidGenerator guidGenerator,
            ICurrentTenant currentTenant,
            IServiceProvider serviceProvider,
            IOrderNumberGenerator orderNumberGenerator,
            IProductSkuDescriptionProvider productSkuDescriptionProvider)
            : base(clock, guidGenerator, currentTenant, serviceProvider, orderNumberGenerator, productSkuDescriptionProvider)
        {
        }

        protected override Task<string> GetStoreCurrencyAsync(Guid storeId)
        {
            return Task.FromResult("NTD") ;
        }
    }
}
