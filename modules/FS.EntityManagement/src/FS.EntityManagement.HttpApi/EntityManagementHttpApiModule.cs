using Localization.Resources.AbpUi;
using FS.Entity.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace FS.EntityManagement
{
    [DependsOn(
    typeof(EntityManagementApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
    public class EntityManagementHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(EntityManagementHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<EntityResource>();
                    //.AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}


