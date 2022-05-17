using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace FS.CmsKit.ContentComposites;

[DependsOn(
    typeof(ContentCompositesApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class ContentCompositesHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(ContentCompositesApplicationContractsModule).Assembly,
            ContentCompositesRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ContentCompositesHttpApiClientModule>();
        });

    }
}
