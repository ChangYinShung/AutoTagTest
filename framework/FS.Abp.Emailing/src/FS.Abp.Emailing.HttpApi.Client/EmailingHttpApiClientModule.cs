using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace FS.Abp.Emailing;

[DependsOn(
    typeof(EmailingApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class EmailingHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(EmailingApplicationContractsModule).Assembly,
            EmailingRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<EmailingHttpApiClientModule>();
        });

    }
}
