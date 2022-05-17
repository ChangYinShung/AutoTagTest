using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FS.EShopManagement.EntityFrameworkCore;

public class EShopManagementHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<EShopManagementHttpApiHostMigrationsDbContext>
{
    public EShopManagementHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<EShopManagementHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("EShopManagement"));

        return new EShopManagementHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
