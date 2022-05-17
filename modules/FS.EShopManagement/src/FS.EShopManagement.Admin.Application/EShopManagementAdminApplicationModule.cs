using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace FS.EShopManagement.Admin;

[DependsOn(
    typeof(EShopManagementDomainModule),
    typeof(EShopManagementAdminApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
[DependsOn(
    typeof(EasyAbp.EShop.Orders.EShopOrdersApplicationModule),
    typeof(EasyAbp.EShop.Payments.EShopPaymentsApplicationModule),
    typeof(EasyAbp.EShop.Products.EShopProductsApplicationModule)
    )]
public class EShopManagementAdminApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<EShopManagementAdminApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<EShopManagementAdminApplicationModule>(validate: false);
        });
    }
}
