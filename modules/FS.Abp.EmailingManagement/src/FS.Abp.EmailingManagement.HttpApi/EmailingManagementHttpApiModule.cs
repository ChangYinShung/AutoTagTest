using Localization.Resources.AbpUi;
using FS.Abp.EmailingManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace FS.Abp.EmailingManagement;

[DependsOn(
    typeof(EmailingManagementApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class EmailingManagementHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(EmailingManagementHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<EmailingManagementResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
