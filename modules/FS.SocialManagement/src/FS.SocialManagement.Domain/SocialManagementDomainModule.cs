using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace FS.SocialManagement;

[DependsOn(typeof(FS.Social.SocialDomainModule))]
[DependsOn(
    typeof(SocialManagementDomainSharedModule)
)]
public class SocialManagementDomainModule : AbpModule
{

}
