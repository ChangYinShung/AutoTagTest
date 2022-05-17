using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.Payment.EcPay.MongoDB;

[ConnectionStringName(EcPayDbProperties.ConnectionStringName)]
public interface IEcPayMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
