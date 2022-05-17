using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace FS.LineNotify;

public class LineNotifyCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        Configure<ServiceDefinitionOptions>(configuration.GetSection("LineNotify:ServiceDefinition"));
    }
}
