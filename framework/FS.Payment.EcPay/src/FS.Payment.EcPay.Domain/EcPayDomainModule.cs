using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace FS.Payment.EcPay;

[DependsOn(
    typeof(Volo.Payment.AbpPaymentDomainModule)
)]
public class EcPayDomainModule : AbpModule
{

}
