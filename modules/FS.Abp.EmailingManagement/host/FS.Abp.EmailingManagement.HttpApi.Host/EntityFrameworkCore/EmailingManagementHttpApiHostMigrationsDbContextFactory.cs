using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FS.Abp.EmailingManagement.EntityFrameworkCore;

public class EmailingManagementHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<EmailingManagementHttpApiHostMigrationsDbContext>
{
    public EmailingManagementHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<EmailingManagementHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("EmailingManagement"));

        return new EmailingManagementHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
