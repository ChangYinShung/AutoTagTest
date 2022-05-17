using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace FS.EcPay
{
    public class EcPayCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            Configure<HttpClientOptions>(configuration.GetSection("EcPay:HttpClient"));
        }
    }
}