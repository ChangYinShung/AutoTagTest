using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.Abp.EmailingManagement.MongoDB;

[ConnectionStringName(EmailingManagementDbProperties.ConnectionStringName)]
public class EmailingManagementMongoDbContext : AbpMongoDbContext, IEmailingManagementMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureEmailingManagement();
    }
}
