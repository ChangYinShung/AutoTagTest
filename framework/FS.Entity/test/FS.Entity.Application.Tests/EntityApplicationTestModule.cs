using Volo.Abp.Modularity;

namespace FS.Entity;

[DependsOn(
    typeof(EntityApplicationModule),
    typeof(EntityDomainTestModule)
    )]
public class EntityApplicationTestModule : AbpModule
{

}
