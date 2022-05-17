using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace FS.FormManagement;

[DependsOn(
    typeof(FormManagementApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class FormManagementHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(FormManagementApplicationContractsModule).Assembly,
            FormManagementRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<FormManagementHttpApiClientModule>();
        });

    }
}
