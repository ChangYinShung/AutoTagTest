using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace FS.Tspg;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(TspgDomainSharedModule)
)]
public class TspgDomainModule : AbpModule
{

}
