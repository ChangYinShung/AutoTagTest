using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace FS.EShopManagement.EntityFrameworkCore;

[ConnectionStringName(EShopManagementDbProperties.ConnectionStringName)]
public class EShopManagementDbContext : AbpDbContext<EShopManagementDbContext>, IEShopManagementDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public EShopManagementDbContext(DbContextOptions<EShopManagementDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureEShopManagement();
    }
}
