using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace FS.Entity.EntityFrameworkCore;

[ConnectionStringName(EntityDbProperties.ConnectionStringName)]
public class EntityDbContext : AbpDbContext<EntityDbContext>, IEntityDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public EntityDbContext(DbContextOptions<EntityDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureEntity();
    }
}
