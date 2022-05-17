using FS.Payment.Tspg.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace FS.Payment.Tspg.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(TspgEntityFrameworkCoreModule),
    typeof(TspgApplicationContractsModule)
    )]
public class TspgDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
