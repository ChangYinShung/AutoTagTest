using Localization.Resources.AbpUi;
using FS.EShopManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace FS.EShopManagement;

[DependsOn(
    typeof(EShopManagementApplicationModule),
    typeof(EntityFrameworkCore.EShopManagementEntityFrameworkCoreModule),
    typeof(EShopManagementHttpApiModule),
    typeof(FS.PaymentService.PaymentServiceAspNetCoreModule)
    )]
public class EShopManagementAspNetCoreModule : AbpModule
{


    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(EShopManagementApplicationModule).Assembly, c =>
            {
                c.RootPath = EShopManagementRemoteServiceConsts.ModuleName;
                c.RemoteServiceName = EShopManagementRemoteServiceConsts.RemoteServiceName;
            });

            options.ConventionalControllers.Create(typeof(FS.EShopManagement.Admin.EShopManagementAdminApplicationModule).Assembly, c =>
            {
                c.RootPath = EShopManagementRemoteServiceConsts.ModuleName;
                c.RemoteServiceName = EShopManagementRemoteServiceConsts.RemoteServiceName;
                c.UrlControllerNameNormalizer = (c) => "admin/" + c.ControllerName.ToLower();
            });

            options.ConventionalControllers.Create(typeof(FS.EShopManagement.Public.EShopManagementPublicApplicationModule).Assembly, c =>
            {
                c.RootPath = EShopManagementRemoteServiceConsts.ModuleName;
                c.RemoteServiceName = EShopManagementRemoteServiceConsts.RemoteServiceName;
                c.UrlControllerNameNormalizer = (c) => "public/" + c.ControllerName.ToLower();
            });
        });
    }
}
