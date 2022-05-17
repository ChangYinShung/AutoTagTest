using FS.SocialManagement.EntityFrameworkCore;
using FS.SocialManagement.EntityFrameworkCore.DbMigrator;
using Volo.Abp.Autofac;
//using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace FS.SocialManagement.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(FS.SocialManagement.EntityFrameworkCore.DbMigrator.SocialManagementEntityFrameworkCoreModule),
    typeof(SocialManagementApplicationContractsModule)
    )]
public class SocialManagementDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
