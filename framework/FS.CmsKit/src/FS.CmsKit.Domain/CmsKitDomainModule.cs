using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace FS.CmsKit;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(CmsKitDomainSharedModule)
)]
public class CmsKitDomainModule : AbpModule
{

}
