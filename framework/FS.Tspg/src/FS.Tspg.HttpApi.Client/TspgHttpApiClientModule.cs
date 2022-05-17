using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace FS.Tspg;

[DependsOn(
    typeof(TspgApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class TspgHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(TspgApplicationContractsModule).Assembly,
            TspgRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<TspgHttpApiClientModule>();
        });

    }
}
