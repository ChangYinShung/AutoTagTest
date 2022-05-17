using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace FS.EntityManagement
{
    [DependsOn(
      typeof(AbpDddDomainModule),
      typeof(EntityManagementDomainSharedModule)
    )]
    [DependsOn(typeof(FS.Abp.Data.AbpDataModule))]
    [DependsOn(
        typeof(FS.Entity.EntityDefaults.EntityDefaultsDomainModule),
        typeof(FS.Entity.EntityFeatures.EntityFeaturesDomainModule),
        typeof(FS.Entity.MultiLinguals.MultiLingualsDomainModule)
        )]
    public class EntityManagementDomainModule : AbpModule
    {

    }
}


