using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FS.Abp.Emailing.EntityFrameworkCore;

public class EmailingHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<EmailingHttpApiHostMigrationsDbContext>
{
    public EmailingHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<EmailingHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Emailing"));

        return new EmailingHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
