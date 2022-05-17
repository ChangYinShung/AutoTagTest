using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace FS.EShopManagement.Public;

[DependsOn(
    typeof(EShopManagementDomainModule),
    typeof(EShopManagementPublicApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
[DependsOn(
    typeof(EasyAbp.EShop.Orders.EShopOrdersApplicationModule),
    typeof(EasyAbp.EShop.Products.EShopProductsApplicationModule)
    )]
public class EShopManagementPublicApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<EShopManagementPublicApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<EShopManagementPublicApplicationModule>(validate: false);
        });
    }
}
