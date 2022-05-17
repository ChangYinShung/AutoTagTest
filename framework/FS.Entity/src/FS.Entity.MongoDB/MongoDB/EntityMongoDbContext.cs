using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.Entity.MongoDB;

[ConnectionStringName(EntityDbProperties.ConnectionStringName)]
public class EntityMongoDbContext : AbpMongoDbContext, IEntityMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureEntity();
    }
}
