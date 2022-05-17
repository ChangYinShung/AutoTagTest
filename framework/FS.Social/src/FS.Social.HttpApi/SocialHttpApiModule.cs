using Localization.Resources.AbpUi;
using FS.Social.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace FS.Social;

[DependsOn(
    typeof(SocialApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class SocialHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(SocialHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            //options.Resources
            //    .Get<SocialResource>()
            //    .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
