using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FS.EntityManagement.EntityFrameworkCore;

public class EntityManagementHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<EntityManagementHttpApiHostMigrationsDbContext>
{
    public EntityManagementHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<EntityManagementHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("EntityManagement"));

        return new EntityManagementHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
