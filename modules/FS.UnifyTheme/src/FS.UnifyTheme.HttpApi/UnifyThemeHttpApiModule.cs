using Localization.Resources.AbpUi;
using FS.UnifyTheme.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace FS.UnifyTheme
{
    [DependsOn(
        typeof(UnifyThemeApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class UnifyThemeHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(UnifyThemeHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<UnifyThemeResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
