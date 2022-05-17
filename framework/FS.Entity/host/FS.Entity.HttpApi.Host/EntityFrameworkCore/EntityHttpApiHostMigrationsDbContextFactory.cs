using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FS.Entity.EntityFrameworkCore;

public class EntityHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<EntityHttpApiHostMigrationsDbContext>
{
    public EntityHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<EntityHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Entity"));

        return new EntityHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
