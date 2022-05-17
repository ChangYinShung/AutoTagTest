using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace FS.Abp.EmailingManagement;

[DependsOn(
    typeof(EmailingManagementApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class EmailingManagementHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(EmailingManagementApplicationContractsModule).Assembly,
            EmailingManagementRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<EmailingManagementHttpApiClientModule>();
        });

    }
}
