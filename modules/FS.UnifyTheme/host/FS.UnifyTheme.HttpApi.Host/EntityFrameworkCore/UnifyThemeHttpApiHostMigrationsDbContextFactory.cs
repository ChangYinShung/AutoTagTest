using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FS.UnifyTheme.EntityFrameworkCore
{
    public class UnifyThemeHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<UnifyThemeHttpApiHostMigrationsDbContext>
    {
        public UnifyThemeHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<UnifyThemeHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("UnifyTheme"));

            return new UnifyThemeHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
