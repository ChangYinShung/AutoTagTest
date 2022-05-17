using Volo.Abp.Modularity;

namespace FS.Payment.EcPay;

[DependsOn(
    typeof(EcPayApplicationModule),
    typeof(EcPayDomainTestModule)
    )]
public class EcPayApplicationTestModule : AbpModule
{

}
