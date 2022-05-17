using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FS.SocialManagement.EntityFrameworkCore;

public class SocialManagementHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<SocialManagementHttpApiHostMigrationsDbContext>
{
    public SocialManagementHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<SocialManagementHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("SocialManagement"));

        return new SocialManagementHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
