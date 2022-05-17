using FS.EShopManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FS.EShopManagement;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(EShopManagementEntityFrameworkCoreTestModule)
    )]
public class EShopManagementDomainTestModule : AbpModule
{

}
