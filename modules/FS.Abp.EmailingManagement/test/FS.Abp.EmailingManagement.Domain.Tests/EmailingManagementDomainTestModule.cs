using FS.Abp.EmailingManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FS.Abp.EmailingManagement;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(EmailingManagementEntityFrameworkCoreTestModule)
    )]
public class EmailingManagementDomainTestModule : AbpModule
{

}
