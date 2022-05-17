using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;

namespace FS.CmsKit.ContentComposites.EntityFrameworkCore;

[DependsOn(
    typeof(ContentCompositesDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
[DependsOn(typeof(EasyAbp.Abp.Trees.EntityFrameworkCore.AbpTreesEntityFrameworkCoreModule))]
public class ContentCompositesEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<ContentCompositesDbContext>(options =>
        {
            options.TreeEntity<ContentComponent>(option =>
            {
            });
            //options.AddDefaultTreeRepositories();

            /* Add custom repositories here. Example:
             * options.AddRepository<Question, EfCoreQuestionRepository>();
             */
        });

        context.Services.AddDefaultRepository(
            typeof(ContentComponent),
            typeof(EfCoreContentComponentTreeRepository), true);
    }
}
