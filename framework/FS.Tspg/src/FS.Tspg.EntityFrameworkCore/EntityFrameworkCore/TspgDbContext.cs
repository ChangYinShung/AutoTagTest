using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace FS.Tspg.EntityFrameworkCore;

[ConnectionStringName(TspgDbProperties.ConnectionStringName)]
public class TspgDbContext : AbpDbContext<TspgDbContext>, ITspgDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public TspgDbContext(DbContextOptions<TspgDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureTspg();
    }
}
