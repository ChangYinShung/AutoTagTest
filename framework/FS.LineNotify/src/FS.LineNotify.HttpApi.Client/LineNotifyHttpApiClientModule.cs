using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace FS.LineNotify;

[DependsOn(
    typeof(LineNotifyApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class LineNotifyHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(LineNotifyApplicationContractsModule).Assembly,
            LineNotifyRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<LineNotifyHttpApiClientModule>();
        });

    }
}
