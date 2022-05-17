using FS.CmsKit.ContentDefinitions.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FS.CmsKit.ContentDefinitions;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(ContentDefinitionsEntityFrameworkCoreTestModule)
    )]
public class ContentDefinitionsDomainTestModule : AbpModule
{

}
