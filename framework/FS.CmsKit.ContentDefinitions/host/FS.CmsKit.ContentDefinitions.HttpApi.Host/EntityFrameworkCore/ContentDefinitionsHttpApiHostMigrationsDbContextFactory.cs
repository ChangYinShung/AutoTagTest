using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FS.CmsKit.ContentDefinitions.EntityFrameworkCore;

public class ContentDefinitionsHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<ContentDefinitionsHttpApiHostMigrationsDbContext>
{
    public ContentDefinitionsHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<ContentDefinitionsHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("ContentDefinitions"));

        return new ContentDefinitionsHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
