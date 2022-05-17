using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.Social.MongoDB;

[ConnectionStringName(SocialDbProperties.ConnectionStringName)]
public class SocialMongoDbContext : AbpMongoDbContext, ISocialMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureSocial();
    }
}
