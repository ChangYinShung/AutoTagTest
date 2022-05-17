using Localization.Resources.AbpUi;
using FS.EShopManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Uow;

namespace FS.EShopManagement;

[DependsOn(
    typeof(EShopManagementApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
[DependsOn(
    typeof(EasyAbp.EShop.Orders.EShopOrdersHttpApiModule),
    typeof(EasyAbp.EShop.Payments.EShopPaymentsHttpApiModule),
    typeof(EasyAbp.EShop.Products.EShopProductsHttpApiModule),
    typeof(EasyAbp.EShop.Stores.EShopStoresHttpApiModule)
    )]
public class EShopManagementHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(EShopManagementHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<EShopManagementResource>();
                //.AddBaseTypes(typeof(AbpUiResource));
        });

        Configure<AbpAspNetCoreUnitOfWorkOptions>(options =>
        {
            options.IgnoredUrls.Add(@"/api/e-shop-management");
        });
    }
}
