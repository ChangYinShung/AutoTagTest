using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace FS.EcPay;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(EcPayDomainSharedModule)
)]
public class EcPayDomainModule : AbpModule
{

}
