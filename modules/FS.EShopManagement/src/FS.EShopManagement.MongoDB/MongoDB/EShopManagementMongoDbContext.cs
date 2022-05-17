using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.EShopManagement.MongoDB;

[ConnectionStringName(EShopManagementDbProperties.ConnectionStringName)]
public class EShopManagementMongoDbContext : AbpMongoDbContext, IEShopManagementMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureEShopManagement();
    }
}
