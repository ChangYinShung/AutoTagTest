using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.SocialManagement.MongoDB;

[ConnectionStringName(SocialManagementDbProperties.ConnectionStringName)]
public class SocialManagementMongoDbContext : AbpMongoDbContext, ISocialManagementMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureSocialManagement();
    }
}
