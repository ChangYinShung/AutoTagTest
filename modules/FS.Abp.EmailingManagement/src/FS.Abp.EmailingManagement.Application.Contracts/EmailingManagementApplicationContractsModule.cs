using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace FS.Abp.EmailingManagement;

[DependsOn(
    typeof(EmailingManagementDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class EmailingManagementApplicationContractsModule : AbpModule
{

}
