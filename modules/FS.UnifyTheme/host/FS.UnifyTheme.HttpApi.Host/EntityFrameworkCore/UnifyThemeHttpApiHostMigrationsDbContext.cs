using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FS.UnifyTheme.EntityFrameworkCore
{
    public class UnifyThemeHttpApiHostMigrationsDbContext : AbpDbContext<UnifyThemeHttpApiHostMigrationsDbContext>
    {
        public UnifyThemeHttpApiHostMigrationsDbContext(DbContextOptions<UnifyThemeHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureUnifyTheme();
        }
    }
}
