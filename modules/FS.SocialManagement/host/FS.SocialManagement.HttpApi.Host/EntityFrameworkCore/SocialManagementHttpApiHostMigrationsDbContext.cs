using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FS.SocialManagement.EntityFrameworkCore;

public class SocialManagementHttpApiHostMigrationsDbContext : AbpDbContext<SocialManagementHttpApiHostMigrationsDbContext>
{
    public SocialManagementHttpApiHostMigrationsDbContext(DbContextOptions<SocialManagementHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureSocialManagement();
    }
}
