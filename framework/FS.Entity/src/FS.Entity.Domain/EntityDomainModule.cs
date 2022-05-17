using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace FS.Entity;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(EntityDomainSharedModule)
)]
//[DependsOn(typeof(FS.Abp.Settings.SettingsDomainModule))]
public class EntityDomainModule : AbpModule
{

}
