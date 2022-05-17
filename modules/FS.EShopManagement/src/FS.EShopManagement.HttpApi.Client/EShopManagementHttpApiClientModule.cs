using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace FS.EShopManagement;

[DependsOn(
    typeof(EShopManagementApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class EShopManagementHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(EShopManagementApplicationContractsModule).Assembly,
            EShopManagementRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<EShopManagementHttpApiClientModule>();
        });

    }
}
