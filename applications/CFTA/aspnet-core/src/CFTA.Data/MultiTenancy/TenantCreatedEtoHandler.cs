using CFTA.Data.EShop;
using System.Threading.Tasks;
using Volo.Abp.MultiTenancy;

namespace CFTA.Data.MultiTenancy
{
    public class TenantCreatedEtoHandler :
        Volo.Abp.Domain.Services.DomainService,
        Volo.Abp.EventBus.Distributed.IDistributedEventHandler<TenantCreatedEto>,
        Volo.Abp.DependencyInjection.ITransientDependency
    {
        protected EShopDataSeeder EShopManagementDataSeeder => this.LazyServiceProvider.LazyGetRequiredService<EShopDataSeeder>();

        public virtual async Task HandleEventAsync(TenantCreatedEto eventData)//remerber to add virtual
        {
            var dataService = this.LazyServiceProvider.LazyGetRequiredService<DataService>();

            await dataService.ChangeTenantClaimsAsync(eventData.Id, async () =>
            {
                await this.EShopManagementDataSeeder.CreateStoresAndProductsAsync();

            });
        }
    }
}
