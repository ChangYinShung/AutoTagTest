using Localization.Resources.AbpUi;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace FS.EcPay;

[DependsOn(
    typeof(AbpAspNetCoreMvcModule),
    typeof(FS.EcPay.EcPayCoreModule)
    )]
public class EcPayHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(EcPayHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //Configure<AbpLocalizationOptions>(options =>
        //{
        //    options.Resources
        //        .Get<EcPayResource>()
        //        .AddBaseTypes(typeof(AbpUiResource));
        //});
    }
}
