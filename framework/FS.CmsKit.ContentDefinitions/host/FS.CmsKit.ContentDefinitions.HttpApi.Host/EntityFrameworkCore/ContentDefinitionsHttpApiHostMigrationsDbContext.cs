using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FS.CmsKit.ContentDefinitions.EntityFrameworkCore;

public class ContentDefinitionsHttpApiHostMigrationsDbContext : AbpDbContext<ContentDefinitionsHttpApiHostMigrationsDbContext>
{
    public ContentDefinitionsHttpApiHostMigrationsDbContext(DbContextOptions<ContentDefinitionsHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureContentDefinitions();
    }
}
