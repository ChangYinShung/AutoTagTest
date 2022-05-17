using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using FS.SocialManagement.EntityFrameworkCore;
namespace FS.SocialManagement.EntityFrameworkCore.DbMigrator;

[ConnectionStringName(SocialManagementDbProperties.ConnectionStringName)]
public class SocialManagementDbContext :
    AbpDbContext<SocialManagementDbContext>
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    public SocialManagementDbContext(DbContextOptions<SocialManagementDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureSocialManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(SocialManagementConsts.DbTablePrefix + "YourEntities", SocialManagementConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
