using Localization.Resources.AbpUi;
using FS.CmsKit.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace FS.CmsKit;

[DependsOn(
    typeof(CmsKitApplicationModule),
    typeof(EntityFrameworkCore.CmsKitEntityFrameworkCoreModule),
    typeof(CmsKitHttpApiModule))]
public class CmsKitAspNetCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(CmsKitApplicationModule).Assembly, c =>
            {
                c.RootPath = CmsKitRemoteServiceConsts.ModuleName;
                c.RemoteServiceName = CmsKitRemoteServiceConsts.RemoteServiceName;
            });

        });
    }
}
