using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FS.EcPay.EntityFrameworkCore;

public class EcPayHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<EcPayHttpApiHostMigrationsDbContext>
{
    public EcPayHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<EcPayHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("EcPay"));

        return new EcPayHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
