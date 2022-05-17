using Volo.Abp.Modularity;

namespace FS.CmsKit;

[DependsOn(
    typeof(CmsKitApplicationModule),
    typeof(CmsKitDomainTestModule)
    )]
public class CmsKitApplicationTestModule : AbpModule
{

}
