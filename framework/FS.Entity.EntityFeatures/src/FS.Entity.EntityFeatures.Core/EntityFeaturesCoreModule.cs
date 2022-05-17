using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Volo.Abp.Modularity;

namespace FS.Entity.EntityFeatures
{
    [DependsOn(typeof(FS.Abp.AutoFilterer.AbpAutoFiltererCoreModule))]
    public class EntityFeaturesCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

            var preActions = context.Services.GetPreConfigureActions<EntityFeaturesOptions>();

            Configure<EntityFeaturesOptions>(entityFeaturesOptions =>
            {
                preActions.Configure(entityFeaturesOptions);
            });

        }
    }
}
