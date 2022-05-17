using Volo.Abp;
using Volo.Abp.MongoDB;

namespace FS.Entity.MongoDB;

public static class EntityMongoDbContextExtensions
{
    public static void ConfigureEntity(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
