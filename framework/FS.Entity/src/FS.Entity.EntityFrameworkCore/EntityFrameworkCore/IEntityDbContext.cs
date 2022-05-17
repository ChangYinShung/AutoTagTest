using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace FS.Entity.EntityFrameworkCore;

[ConnectionStringName(EntityDbProperties.ConnectionStringName)]
public interface IEntityDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
