using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.CmsKit.MongoDB;

[ConnectionStringName(CmsKitDbProperties.ConnectionStringName)]
public class CmsKitMongoDbContext : AbpMongoDbContext, ICmsKitMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureCmsKit();
    }
}
