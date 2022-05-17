using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FS.CmsKit.ContentComposites.EntityFrameworkCore;

public class ContentCompositesHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<ContentCompositesHttpApiHostMigrationsDbContext>
{
    public ContentCompositesHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<ContentCompositesHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("ContentComposites"));

        return new ContentCompositesHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
