using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FS.Abp.Emailing.EntityFrameworkCore;

public class EmailingHttpApiHostMigrationsDbContext : AbpDbContext<EmailingHttpApiHostMigrationsDbContext>
{
    public EmailingHttpApiHostMigrationsDbContext(DbContextOptions<EmailingHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureEmailing();
    }
}
