using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace FS.CmsKit.ContentDefinitions.MongoDB;

[DependsOn(
    typeof(ContentDefinitionsDomainModule),
    typeof(AbpMongoDbModule)
    )]
public class ContentDefinitionsMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<ContentDefinitionsMongoDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
        });
    }
}
