using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FS.Tspg.EntityFrameworkCore;

public class TspgHttpApiHostMigrationsDbContext : AbpDbContext<TspgHttpApiHostMigrationsDbContext>
{
    public TspgHttpApiHostMigrationsDbContext(DbContextOptions<TspgHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureTspg();
    }
}
