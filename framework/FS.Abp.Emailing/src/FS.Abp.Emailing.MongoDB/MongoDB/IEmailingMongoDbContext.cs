using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.Abp.Emailing.MongoDB;

[ConnectionStringName(EmailingDbProperties.ConnectionStringName)]
public interface IEmailingMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
