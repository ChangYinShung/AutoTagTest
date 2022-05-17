using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FS.EntityManagement.EntityFrameworkCore
{
    [DependsOn(
     typeof(EntityManagementDomainModule),
     typeof(AbpEntityFrameworkCoreModule)
    )]
    [DependsOn(typeof(FS.Entity.EntityDefaults.EntityFrameworkCore.EntityDefaultsEntityFrameworkCoreModule))]
    [DependsOn(typeof(FS.Entity.MultiLinguals.EntityFrameworkCore.MultiLingualsEntityFrameworkCoreModule))]
    public class EntityManagementEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<EntityManagementDbContext>(options =>
            {
                options.AddDefaultRepositories(true);
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
            });
        }
    }
}


