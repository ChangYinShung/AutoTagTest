using Localization.Resources.AbpUi;
using FS.Abp.Emailing.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace FS.Abp.Emailing;

[DependsOn(
    typeof(EmailingApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class EmailingHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(EmailingHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<EmailingResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
