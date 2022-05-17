using Localization.Resources.AbpUi;
using FS.CmsKit.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace FS.CmsKit.ContentDefinitions;

[DependsOn(
    typeof(ContentDefinitionsApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class ContentDefinitionsHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(ContentDefinitionsHttpApiModule).Assembly);
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
