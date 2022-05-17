using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.Abp.EmailingManagement.MongoDB;

[ConnectionStringName(EmailingManagementDbProperties.ConnectionStringName)]
public interface IEmailingManagementMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
