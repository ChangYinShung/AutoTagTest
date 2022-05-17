using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace FS.Abp.Emailing.EntityFrameworkCore;

[ConnectionStringName(EmailingDbProperties.ConnectionStringName)]
public interface IEmailingDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
