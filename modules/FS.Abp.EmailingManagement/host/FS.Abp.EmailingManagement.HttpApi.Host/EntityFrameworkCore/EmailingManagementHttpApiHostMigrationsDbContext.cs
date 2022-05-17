using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FS.Abp.EmailingManagement.EntityFrameworkCore;

public class EmailingManagementHttpApiHostMigrationsDbContext : AbpDbContext<EmailingManagementHttpApiHostMigrationsDbContext>
{
    public EmailingManagementHttpApiHostMigrationsDbContext(DbContextOptions<EmailingManagementHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureEmailingManagement();
    }
}
