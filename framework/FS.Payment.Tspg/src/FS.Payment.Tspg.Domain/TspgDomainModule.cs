using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Domain;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Payment;

namespace FS.Payment.Tspg;

[DependsOn(
    typeof(Volo.Payment.AbpPaymentDomainModule)
)]
[DependsOn(typeof(FS.Payment.Tspg.TspgDomainSharedModule))]
public class TspgDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<PaymentOptions>(options =>
        {
            options.Gateways.Add(
                new PaymentGatewayConfiguration(
                    TspgConsts.GatewayName,
                    new FixedLocalizableString("Tspg"),
                    isSubscriptionSupported: true,
                    typeof(TspgPaymentGateway)
                )
            );
        });
    }
}
