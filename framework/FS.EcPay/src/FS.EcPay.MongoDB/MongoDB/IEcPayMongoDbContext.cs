using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.EcPay.MongoDB;

[ConnectionStringName(EcPayDbProperties.ConnectionStringName)]
public interface IEcPayMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
