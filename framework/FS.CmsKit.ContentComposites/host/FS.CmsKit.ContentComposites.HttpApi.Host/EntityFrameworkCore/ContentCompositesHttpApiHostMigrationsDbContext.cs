using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FS.CmsKit.ContentComposites.EntityFrameworkCore;

public class ContentCompositesHttpApiHostMigrationsDbContext : AbpDbContext<ContentCompositesHttpApiHostMigrationsDbContext>
{
    public ContentCompositesHttpApiHostMigrationsDbContext(DbContextOptions<ContentCompositesHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureContentComposites();
    }
}
