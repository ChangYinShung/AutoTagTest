using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.SocialManagement.MongoDB;

[ConnectionStringName(SocialManagementDbProperties.ConnectionStringName)]
public interface ISocialManagementMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
