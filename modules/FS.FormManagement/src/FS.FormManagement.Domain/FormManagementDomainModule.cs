using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace FS.FormManagement
{

    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(FormManagementDomainSharedModule)
    )]
    [DependsOn(typeof(Volo.Forms.FormsDomainModule))]
    public class FormManagementDomainModule : AbpModule
    {
    }
}