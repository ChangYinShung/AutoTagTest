using Volo.Abp;
using Volo.Abp.MongoDB;

namespace FS.EShopManagement.MongoDB;

public static class EShopManagementMongoDbContextExtensions
{
    public static void ConfigureEShopManagement(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
