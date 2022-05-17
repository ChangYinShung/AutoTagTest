using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace FS.PaymentService.Tspg;

[DependsOn(
    typeof(FS.PaymentService.PaymentServiceDomainModule),
    typeof(FS.Tspg.TspgCoreModule)
    )]
public class PaymentServiceTspgDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        
        Configure<PaymentServiceOptions>(configuration.GetSection("Tspg:PaymentService"));
    }
}
