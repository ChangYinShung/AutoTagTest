using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.EntityManagement.MongoDB;

[ConnectionStringName(EntityManagementDbProperties.ConnectionStringName)]
public interface IEntityManagementMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
