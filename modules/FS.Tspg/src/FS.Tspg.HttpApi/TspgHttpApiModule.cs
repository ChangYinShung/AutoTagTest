using Localization.Resources.AbpUi;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace FS.Tspg;

[DependsOn(
    typeof(AbpAspNetCoreMvcModule),
    typeof(TspgCoreModule)
    )]
public class TspgHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(TspgHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //Configure<AbpLocalizationOptions>(options =>
        //{
        //    options.Resources
        //        .Get<TspgResource>()
        //        .AddBaseTypes(typeof(AbpUiResource));
        //});
    }
}
