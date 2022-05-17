using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace FS.Payment.EcPay.EntityFrameworkCore;

[ConnectionStringName(EcPayDbProperties.ConnectionStringName)]
public interface IEcPayDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
