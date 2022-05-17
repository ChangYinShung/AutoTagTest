using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FS.EcPay.EntityFrameworkCore;

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
