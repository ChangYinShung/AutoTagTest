using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FS.Entity.EntityFrameworkCore;

public class EntityHttpApiHostMigrationsDbContext : AbpDbContext<EntityHttpApiHostMigrationsDbContext>
{
    public EntityHttpApiHostMigrationsDbContext(DbContextOptions<EntityHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureEntity();
    }
}
