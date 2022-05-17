using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace FS.PaymentService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(FS.Abp.Data.AbpDataModule),
    typeof(PaymentServiceDomainSharedModule),
    typeof(PaymentServiceCoreModule)
)]
public class PaymentServiceDomainModule : AbpModule
{

}
