using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FS.EShopManagement.EntityFrameworkCore;

public class EShopManagementHttpApiHostMigrationsDbContext : AbpDbContext<EShopManagementHttpApiHostMigrationsDbContext>
{
    public EShopManagementHttpApiHostMigrationsDbContext(DbContextOptions<EShopManagementHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureEShopManagement();
    }
}
