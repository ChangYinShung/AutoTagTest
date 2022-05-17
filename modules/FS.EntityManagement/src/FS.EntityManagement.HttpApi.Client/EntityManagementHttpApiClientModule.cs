using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace FS.EntityManagement;

[DependsOn(
    typeof(EntityManagementApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class EntityManagementHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(EntityManagementApplicationContractsModule).Assembly,
            EntityManagementRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<EntityManagementHttpApiClientModule>();
        });

    }
}
