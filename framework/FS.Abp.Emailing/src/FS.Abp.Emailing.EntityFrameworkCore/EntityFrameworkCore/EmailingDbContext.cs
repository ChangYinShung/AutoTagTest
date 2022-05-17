using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace FS.Abp.Emailing.EntityFrameworkCore;

[ConnectionStringName(EmailingDbProperties.ConnectionStringName)]
public class EmailingDbContext : AbpDbContext<EmailingDbContext>, IEmailingDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public EmailingDbContext(DbContextOptions<EmailingDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureEmailing();
    }
}
