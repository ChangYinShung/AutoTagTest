using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.Social.MongoDB;

[ConnectionStringName(SocialDbProperties.ConnectionStringName)]
public interface ISocialMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
