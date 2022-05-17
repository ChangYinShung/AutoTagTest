using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace FS.EShopManagement.EntityFrameworkCore;

[ConnectionStringName(EShopManagementDbProperties.ConnectionStringName)]
public interface IEShopManagementDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
