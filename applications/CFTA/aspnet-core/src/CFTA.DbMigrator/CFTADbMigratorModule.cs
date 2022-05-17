using CFTA.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace CFTA.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CFTAEntityFrameworkCoreModule),
    typeof(CFTAApplicationModule)
)]
public class CFTADbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options =>
        {
            options.IsJobExecutionEnabled = false;
        });

        context.Services.AddAlwaysAllowAuthorization();
    }
}
