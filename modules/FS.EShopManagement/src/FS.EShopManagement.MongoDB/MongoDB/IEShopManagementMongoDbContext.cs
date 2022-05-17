using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.EShopManagement.MongoDB;

[ConnectionStringName(EShopManagementDbProperties.ConnectionStringName)]
public interface IEShopManagementMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
