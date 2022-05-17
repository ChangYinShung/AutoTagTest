using Volo.Abp;
using Volo.Abp.MongoDB;

namespace FS.CmsKit.ContentComposites.MongoDB;

public static class ContentCompositesMongoDbContextExtensions
{
    public static void ConfigureContentComposites(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
