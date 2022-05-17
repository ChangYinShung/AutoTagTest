using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.CmsKit.ContentComposites.MongoDB;

[ConnectionStringName(ContentCompositesDbProperties.ConnectionStringName)]
public interface IContentCompositesMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
