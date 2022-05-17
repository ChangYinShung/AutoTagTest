using Localization.Resources.AbpUi;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace FS.PaymentService;

[DependsOn(
    typeof(FS.EcPay.HttpClient.EcPayHttpClientCoreModule),
    typeof(FS.Tspg.HttpClient.TspgHttpClientModule)
    )]
public class PaymentServiceAspNetCoreModule : AbpModule
{


    public override void ConfigureServices(ServiceConfigurationContext context)
    {
    }
}
