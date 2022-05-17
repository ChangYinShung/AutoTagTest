using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace FS.UnifyTheme.EntityFrameworkCore
{
    [ConnectionStringName(UnifyThemeDbProperties.ConnectionStringName)]
    public interface IUnifyThemeDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}