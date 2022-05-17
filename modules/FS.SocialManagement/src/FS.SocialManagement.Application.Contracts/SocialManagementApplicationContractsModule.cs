using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace FS.SocialManagement;

[DependsOn(typeof(FS.Social.SocialApplicationContractsModule))]
[DependsOn(
    typeof(SocialManagementDomainSharedModule)
    )]
public class SocialManagementApplicationContractsModule : AbpModule
{

}
