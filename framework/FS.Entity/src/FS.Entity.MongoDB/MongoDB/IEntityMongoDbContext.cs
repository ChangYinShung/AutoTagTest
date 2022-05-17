using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.Entity.MongoDB;

[ConnectionStringName(EntityDbProperties.ConnectionStringName)]
public interface IEntityMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
