using Volo.Abp.Modularity;

namespace FS.CmsKit;

[DependsOn(
    typeof(FS.Abp.AutoFilterer.AbpAutoFiltererCoreModule)
)]
public class CmsKitCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
    }
}
