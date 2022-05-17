using FS.Tspg.HttpClient;
using Volo.Abp.Modularity;

namespace FS.Tspg;

[DependsOn(
    typeof(TspgApplicationModule),
    typeof(TspgDomainTestModule),
    typeof(TspgHttpClientCoreModule)
    )]
public class TspgApplicationTestModule : AbpModule
{

}
