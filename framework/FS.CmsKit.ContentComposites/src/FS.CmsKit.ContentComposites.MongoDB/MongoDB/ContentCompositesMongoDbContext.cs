using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.CmsKit.ContentComposites.MongoDB;

[ConnectionStringName(ContentCompositesDbProperties.ConnectionStringName)]
public class ContentCompositesMongoDbContext : AbpMongoDbContext, IContentCompositesMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureContentComposites();
    }
}
