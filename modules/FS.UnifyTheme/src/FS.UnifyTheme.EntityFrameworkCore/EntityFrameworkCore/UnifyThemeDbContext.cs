using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace FS.UnifyTheme.EntityFrameworkCore
{
    [ConnectionStringName(UnifyThemeDbProperties.ConnectionStringName)]
    public class UnifyThemeDbContext : AbpDbContext<UnifyThemeDbContext>, IUnifyThemeDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public UnifyThemeDbContext(DbContextOptions<UnifyThemeDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureUnifyTheme();
        }
    }
}