using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FS.EntityManagement.EntityFrameworkCore;

public class EntityManagementHttpApiHostMigrationsDbContext : AbpDbContext<EntityManagementHttpApiHostMigrationsDbContext>
{
    public EntityManagementHttpApiHostMigrationsDbContext(DbContextOptions<EntityManagementHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureEntityManagement();
    }
}
