using FS.UnifyTheme.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FS.UnifyTheme
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(UnifyThemeEntityFrameworkCoreTestModule)
        )]
    public class UnifyThemeDomainTestModule : AbpModule
    {
        
    }
}
