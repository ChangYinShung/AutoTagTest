using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FS.Payment.EcPay.EntityFrameworkCore;

public class EcPayHttpApiHostMigrationsDbContext : AbpDbContext<EcPayHttpApiHostMigrationsDbContext>
{
    public EcPayHttpApiHostMigrationsDbContext(DbContextOptions<EcPayHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureEcPay();
    }
}
