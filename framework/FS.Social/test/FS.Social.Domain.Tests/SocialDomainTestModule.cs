using FS.Social.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FS.Social;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(SocialEntityFrameworkCoreTestModule)
    )]
public class SocialDomainTestModule : AbpModule
{

}
