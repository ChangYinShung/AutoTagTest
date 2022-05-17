using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.Tspg.MongoDB;

[ConnectionStringName(TspgDbProperties.ConnectionStringName)]
public class TspgMongoDbContext : AbpMongoDbContext, ITspgMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureTspg();
    }
}
