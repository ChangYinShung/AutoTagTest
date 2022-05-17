using Localization.Resources.AbpUi;
using FS.Social.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace FS.SocialManagement;

[DependsOn(
    typeof(SocialManagementApplicationModule),
    typeof(SocialManagementHttpApiModule),
    typeof(EntityFrameworkCore.SocialManagementEntityFrameworkCoreModule)
    )]

[DependsOn(typeof(FS.Social.LineNotify.LineNotifyAspNetCoreModule))]

public class SocialManagementAspNetCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(SocialManagementHttpApiModule).Assembly);
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
