using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.EcPay.MongoDB;

[ConnectionStringName(EcPayDbProperties.ConnectionStringName)]
public class EcPayMongoDbContext : AbpMongoDbContext, IEcPayMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureEcPay();
    }
}
