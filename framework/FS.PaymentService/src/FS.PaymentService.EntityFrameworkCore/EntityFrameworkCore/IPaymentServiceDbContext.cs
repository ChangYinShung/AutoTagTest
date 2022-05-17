using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace FS.PaymentService.EntityFrameworkCore;

[ConnectionStringName(PaymentServiceDbProperties.ConnectionStringName)]
public interface IPaymentServiceDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
