using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace FS.Tspg.EntityFrameworkCore;

[ConnectionStringName(TspgDbProperties.ConnectionStringName)]
public interface ITspgDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
