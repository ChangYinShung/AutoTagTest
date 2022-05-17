using Volo.Abp;
using Volo.Abp.MongoDB;

namespace FS.EntityManagement.MongoDB;

public static class EntityManagementMongoDbContextExtensions
{
    public static void ConfigureEntityManagement(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
