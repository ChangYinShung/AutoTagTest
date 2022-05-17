using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.EntityManagement.MongoDB;

[ConnectionStringName(EntityManagementDbProperties.ConnectionStringName)]
public class EntityManagementMongoDbContext : AbpMongoDbContext, IEntityManagementMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureEntityManagement();
    }
}
