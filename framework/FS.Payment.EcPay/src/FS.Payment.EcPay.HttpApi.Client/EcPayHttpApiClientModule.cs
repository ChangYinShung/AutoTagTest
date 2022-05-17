using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace FS.Payment.EcPay;

[DependsOn(
    typeof(EcPayApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class EcPayHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(EcPayApplicationContractsModule).Assembly,
            EcPayRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<EcPayHttpApiClientModule>();
        });

    }
}
