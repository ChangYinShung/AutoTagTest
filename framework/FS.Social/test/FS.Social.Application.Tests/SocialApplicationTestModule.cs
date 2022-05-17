using Volo.Abp.Modularity;

namespace FS.Social;

[DependsOn(
    typeof(SocialApplicationModule),
    typeof(SocialDomainTestModule)
    )]
public class SocialApplicationTestModule : AbpModule
{

}
