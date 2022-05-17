using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace FS.Entity.EntityDefaults
{
    [DependsOn(typeof(EntityDefaultsDomainSharedModule))]
    [DependsOn(typeof(FS.Entity.EntityApplicationContractsModule))]
    public class EntityDefaultsApplicationContractsModule : AbpModule
    {

    }
}


