using FS.Abp.Emailing.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FS.Abp.Emailing;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(EmailingEntityFrameworkCoreTestModule)
    )]
public class EmailingDomainTestModule : AbpModule
{

}
