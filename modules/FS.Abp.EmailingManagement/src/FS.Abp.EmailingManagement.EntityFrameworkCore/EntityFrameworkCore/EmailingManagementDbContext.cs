using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace FS.Abp.EmailingManagement.EntityFrameworkCore;

[ConnectionStringName(EmailingManagementDbProperties.ConnectionStringName)]
public class EmailingManagementDbContext : AbpDbContext<EmailingManagementDbContext>, IEmailingManagementDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public EmailingManagementDbContext(DbContextOptions<EmailingManagementDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureEmailingManagement();
    }
}
