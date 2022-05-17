using FS.Entity.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FS.Entity;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(EntityEntityFrameworkCoreTestModule)
    )]
public class EntityDomainTestModule : AbpModule
{

}
