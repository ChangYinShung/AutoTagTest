using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.CmsKit.ContentDefinitions.MongoDB;

[ConnectionStringName(ContentDefinitionsDbProperties.ConnectionStringName)]
public class ContentDefinitionsMongoDbContext : AbpMongoDbContext, IContentDefinitionsMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureContentDefinitions();
    }
}
