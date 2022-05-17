using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace FS.CmsKit;

[DependsOn(
    typeof(CmsKitApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class CmsKitHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(CmsKitApplicationContractsModule).Assembly,
            CmsKitRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CmsKitHttpApiClientModule>();
        });

    }
}
