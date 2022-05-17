using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace FS.Abp.EmailingManagement;

[DependsOn(typeof(EmailingManagementDomainSharedModule))]
[DependsOn(typeof(FS.Abp.Emailing.EmailingDomainModule))]
public class EmailingManagementDomainModule : AbpModule
{

}
