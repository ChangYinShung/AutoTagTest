using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace FS.Tspg.HttpClient;

[DependsOn(
    typeof(Volo.Abp.Json.AbpJsonModule),
    typeof(TspgCoreModule))]
public class TspgHttpClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {

    }
}
