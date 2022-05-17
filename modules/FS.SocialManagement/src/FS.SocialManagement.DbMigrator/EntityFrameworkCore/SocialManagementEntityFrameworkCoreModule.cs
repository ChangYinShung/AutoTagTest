using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace FS.SocialManagement.EntityFrameworkCore.DbMigrator;

[DependsOn(
    typeof(SocialManagementDomainModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule)
    )]
public class SocialManagementEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        SocialManagementEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<SocialManagementDbContext>(options =>
        {
            /* Remove "includeAllEntities: true" to create
             * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        Configure<AbpDbContextOptions>(options =>
        {
            /* The main point to change your DBMS.
             * See also SocialManagementMigrationsDbContextFactory for EF Core tooling. */
            options.UseSqlServer();
        });
    }
}
