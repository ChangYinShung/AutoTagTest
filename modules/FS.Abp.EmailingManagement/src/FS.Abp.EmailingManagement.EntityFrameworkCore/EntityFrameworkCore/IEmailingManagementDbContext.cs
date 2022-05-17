using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace FS.Abp.EmailingManagement.EntityFrameworkCore;

[ConnectionStringName(EmailingManagementDbProperties.ConnectionStringName)]
public interface IEmailingManagementDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
