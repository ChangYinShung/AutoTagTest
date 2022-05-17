using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace FS.EcPay.EntityFrameworkCore;

[ConnectionStringName(EcPayDbProperties.ConnectionStringName)]
public class EcPayDbContext : AbpDbContext<EcPayDbContext>, IEcPayDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public EcPayDbContext(DbContextOptions<EcPayDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureEcPay();
    }
}
