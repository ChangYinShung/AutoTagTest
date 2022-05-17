using Localization.Resources.AbpUi;
using FS.Payment.EcPay.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace FS.Payment.EcPay;

[DependsOn(
    typeof(EcPayApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
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
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<EcPayResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
