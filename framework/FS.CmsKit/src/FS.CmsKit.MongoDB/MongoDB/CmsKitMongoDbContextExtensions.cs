using Volo.Abp;
using Volo.Abp.MongoDB;

namespace FS.CmsKit.MongoDB;

public static class CmsKitMongoDbContextExtensions
{
    public static void ConfigureCmsKit(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
