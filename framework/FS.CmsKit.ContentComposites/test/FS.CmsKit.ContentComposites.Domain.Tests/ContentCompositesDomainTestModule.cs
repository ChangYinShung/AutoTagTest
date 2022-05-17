using FS.CmsKit.ContentComposites.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FS.CmsKit.ContentComposites;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(ContentCompositesEntityFrameworkCoreTestModule)
    )]
public class ContentCompositesDomainTestModule : AbpModule
{

}
