using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace FS.EntityManagement
{
    [DependsOn(typeof(FS.Entity.EntityApplicationContractsModule))]
    [DependsOn(
     typeof(EntityManagementDomainSharedModule)
     )]
    [DependsOn(typeof(FS.Entity.EntityDefaults.EntityDefaultsApplicationContractsModule))]
    public class EntityManagementApplicationContractsModule : AbpModule
    {

    }
}


