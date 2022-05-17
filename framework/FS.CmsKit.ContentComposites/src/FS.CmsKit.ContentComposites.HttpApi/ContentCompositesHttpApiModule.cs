using Localization.Resources.AbpUi;
using FS.CmsKit.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace FS.CmsKit.ContentComposites;

[DependsOn(
    typeof(ContentCompositesApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class ContentCompositesHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(ContentCompositesHttpApiModule).Assembly);
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
