using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace FS.CmsKit.EntityFrameworkCore;

[ConnectionStringName(CmsKitDbProperties.ConnectionStringName)]
public interface ICmsKitDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
