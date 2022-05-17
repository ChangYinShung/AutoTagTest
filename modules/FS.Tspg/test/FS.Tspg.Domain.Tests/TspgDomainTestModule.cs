using FS.Tspg.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FS.Tspg;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(TspgEntityFrameworkCoreTestModule)
    )]
public class TspgDomainTestModule : AbpModule
{

}
