using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace FS.Entity.EntityFeatures;

[DependsOn(typeof(EntityFeaturesDomainSharedModule))]
[DependsOn(typeof(FS.Entity.EntityApplicationContractsModule))]
public class EntityFeaturesApplicationContractsModule : AbpModule
{

}
