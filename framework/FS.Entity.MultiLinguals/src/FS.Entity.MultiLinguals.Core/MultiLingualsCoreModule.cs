using Volo.Abp.Modularity;

namespace FS.Entity.MultiLinguals
{
    [DependsOn(typeof(FS.Abp.AutoFilterer.AbpAutoFiltererCoreModule))]
    [DependsOn(typeof(FS.Entity.EntityFeatures.EntityFeaturesCoreModule))]
    public class MultiLingualsCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}


