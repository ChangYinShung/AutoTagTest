using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace FS.SocialManagement;

[DependsOn(
    typeof(SocialManagementApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class SocialManagementHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(SocialManagementApplicationContractsModule).Assembly,
            SocialManagementRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SocialManagementHttpApiClientModule>();
        });

    }
}
