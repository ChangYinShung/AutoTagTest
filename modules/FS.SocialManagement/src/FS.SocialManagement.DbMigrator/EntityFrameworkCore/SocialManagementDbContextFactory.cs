using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FS.SocialManagement.EntityFrameworkCore.DbMigrator;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class SocialManagementDbContextFactory : IDesignTimeDbContextFactory<SocialManagementDbContext>
{
    public SocialManagementDbContext CreateDbContext(string[] args)
    {
        SocialManagementEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<SocialManagementDbContext>()
            .UseSqlServer(configuration.GetConnectionString(SocialManagementDbProperties.ConnectionStringName));

        return new SocialManagementDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "./"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
