using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace FS.Entity.EntityDefaults
{
    [DependsOn(typeof(FS.Entity.EntityDomainModule))]
    [DependsOn(
      typeof(EntityDefaultsDomainSharedModule)
  )]
    public class EntityDefaultsDomainModule : AbpModule
    {

    }
}


