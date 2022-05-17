using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace FS.EcPay.HttpClient;

[DependsOn(
    typeof(Volo.Abp.Json.AbpJsonModule))]
[DependsOn(typeof(EcPayCoreModule))]
public class EcPayHttpClientCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
    }
}
