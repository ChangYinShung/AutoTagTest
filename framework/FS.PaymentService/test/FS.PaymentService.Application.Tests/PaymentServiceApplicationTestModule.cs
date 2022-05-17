using Volo.Abp.Modularity;

namespace FS.PaymentService;

[DependsOn(
    typeof(PaymentServiceApplicationModule),
    typeof(PaymentServiceDomainTestModule)
    )]
public class PaymentServiceApplicationTestModule : AbpModule
{

}
