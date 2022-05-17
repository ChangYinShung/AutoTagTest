using Volo.Abp.Modularity;

namespace FS.SocialManagement;

[DependsOn(
    typeof(SocialManagementApplicationModule),
    typeof(SocialManagementDomainTestModule)
    )]
public class SocialManagementApplicationTestModule : AbpModule
{

}
