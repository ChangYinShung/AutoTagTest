using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.PaymentService.MongoDB;

[ConnectionStringName(PaymentServiceDbProperties.ConnectionStringName)]
public interface IPaymentServiceMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
