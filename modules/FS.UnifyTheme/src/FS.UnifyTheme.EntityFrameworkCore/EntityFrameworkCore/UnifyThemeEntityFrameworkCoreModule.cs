using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FS.UnifyTheme.EntityFrameworkCore
{
    [DependsOn(
        typeof(UnifyThemeDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class UnifyThemeEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<UnifyThemeDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
            });
        }
    }
}