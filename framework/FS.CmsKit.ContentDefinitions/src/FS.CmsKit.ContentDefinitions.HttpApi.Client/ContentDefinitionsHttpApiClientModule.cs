using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace FS.CmsKit.ContentDefinitions;

[DependsOn(
    typeof(ContentDefinitionsApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class ContentDefinitionsHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(ContentDefinitionsApplicationContractsModule).Assembly,
            ContentDefinitionsRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ContentDefinitionsHttpApiClientModule>();
        });

    }
}
