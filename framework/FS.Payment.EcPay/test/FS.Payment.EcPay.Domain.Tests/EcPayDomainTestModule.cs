using FS.Payment.EcPay.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FS.Payment.EcPay;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(EcPayEntityFrameworkCoreTestModule)
    )]
public class EcPayDomainTestModule : AbpModule
{

}
