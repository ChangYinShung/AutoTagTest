using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace FS.Social;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(SocialDomainSharedModule)
)]
public class SocialDomainModule : AbpModule
{

}
