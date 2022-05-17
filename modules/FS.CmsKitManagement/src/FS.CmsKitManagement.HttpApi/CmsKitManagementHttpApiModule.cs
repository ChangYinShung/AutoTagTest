using FS.CmsKit.Localization;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace FS.CmsKitManagement
{
    [DependsOn(
        typeof(CmsKitManagementApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    [DependsOn(typeof(Volo.CmsKit.CmsKitHttpApiModule))]
    [DependsOn(
        typeof(FS.CmsKit.ContentDefinitions.ContentDefinitionsHttpApiModule),
        typeof(FS.CmsKit.ContentComposites.ContentCompositesHttpApiModule)
        )]
    public class CmsKitManagementHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(CmsKitManagementHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<CmsKitResource>();
                    //.AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
