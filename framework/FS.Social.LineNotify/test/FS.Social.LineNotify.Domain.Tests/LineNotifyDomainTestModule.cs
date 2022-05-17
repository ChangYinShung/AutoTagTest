using FS.Social.LineNotify.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FS.Social.LineNotify;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(LineNotifyEntityFrameworkCoreTestModule)
    )]
public class LineNotifyDomainTestModule : AbpModule
{

}
