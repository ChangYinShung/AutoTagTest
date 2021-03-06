using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FS.Tspg.EntityFrameworkCore;

public class TspgHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<TspgHttpApiHostMigrationsDbContext>
{
    public TspgHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<TspgHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Tspg"));

        return new TspgHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
