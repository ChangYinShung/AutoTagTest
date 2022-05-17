using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.Tspg.MongoDB;

[ConnectionStringName(TspgDbProperties.ConnectionStringName)]
public interface ITspgMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
