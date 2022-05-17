using Volo.Abp.Modularity;

namespace FS.EcPay;

[DependsOn(
    typeof(EcPayApplicationModule),
    typeof(EcPayDomainTestModule)
    )]
public class EcPayApplicationTestModule : AbpModule
{

}
