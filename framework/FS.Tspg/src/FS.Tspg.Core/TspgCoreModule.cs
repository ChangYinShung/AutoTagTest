using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace FS.Tspg;

public class TspgCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        Configure<HttpClientOptions>(configuration.GetSection("Tspg:HttpClient"));
    }
}
