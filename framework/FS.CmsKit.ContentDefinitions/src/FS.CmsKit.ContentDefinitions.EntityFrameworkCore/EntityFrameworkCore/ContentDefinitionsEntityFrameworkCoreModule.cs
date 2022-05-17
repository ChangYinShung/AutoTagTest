using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FS.CmsKit.ContentDefinitions.EntityFrameworkCore;

[DependsOn(
    typeof(ContentDefinitionsDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class ContentDefinitionsEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<ContentDefinitionsDbContext>(options =>
        {
            options.AddDefaultRepositories();
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, EfCoreQuestionRepository>();
             */
        });

        context.Services.AddAbpMediatR<ContentDefinitionsEntityFrameworkCoreModule>();
    }
}
