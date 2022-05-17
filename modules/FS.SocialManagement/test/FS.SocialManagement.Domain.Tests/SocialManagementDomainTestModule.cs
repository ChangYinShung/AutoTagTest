using FS.SocialManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FS.SocialManagement;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(SocialManagementEntityFrameworkCoreTestModule)
    )]
public class SocialManagementDomainTestModule : AbpModule
{

}
