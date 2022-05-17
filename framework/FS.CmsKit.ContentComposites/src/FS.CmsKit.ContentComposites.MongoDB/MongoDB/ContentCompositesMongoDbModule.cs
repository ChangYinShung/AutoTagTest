using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace FS.CmsKit.ContentComposites.MongoDB;

[DependsOn(
    typeof(ContentCompositesDomainModule),
    typeof(AbpMongoDbModule)
    )]
public class ContentCompositesMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<ContentCompositesMongoDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
        });
    }
}
