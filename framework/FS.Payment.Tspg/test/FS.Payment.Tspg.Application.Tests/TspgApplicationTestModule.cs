using Volo.Abp.Modularity;

namespace FS.Payment.Tspg;

[DependsOn(
    typeof(TspgApplicationModule),
    typeof(TspgDomainTestModule)
    )]
public class TspgApplicationTestModule : AbpModule
{

}
