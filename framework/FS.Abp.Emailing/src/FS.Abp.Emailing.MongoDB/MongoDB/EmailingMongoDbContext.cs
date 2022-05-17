using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.Abp.Emailing.MongoDB;

[ConnectionStringName(EmailingDbProperties.ConnectionStringName)]
public class EmailingMongoDbContext : AbpMongoDbContext, IEmailingMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureEmailing();
    }
}
