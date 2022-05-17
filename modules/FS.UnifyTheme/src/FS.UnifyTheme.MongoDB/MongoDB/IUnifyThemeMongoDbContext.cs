using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.UnifyTheme.MongoDB
{
    [ConnectionStringName(UnifyThemeDbProperties.ConnectionStringName)]
    public interface IUnifyThemeMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
