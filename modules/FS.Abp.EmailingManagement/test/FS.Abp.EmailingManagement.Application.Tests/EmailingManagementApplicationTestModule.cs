using Volo.Abp.Modularity;

namespace FS.Abp.EmailingManagement;

[DependsOn(
    typeof(EmailingManagementApplicationModule),
    typeof(EmailingManagementDomainTestModule)
    )]
public class EmailingManagementApplicationTestModule : AbpModule
{

}
