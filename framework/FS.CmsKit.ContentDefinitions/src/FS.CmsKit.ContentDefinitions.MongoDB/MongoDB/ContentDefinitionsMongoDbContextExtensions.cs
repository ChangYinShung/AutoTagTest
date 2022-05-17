using Volo.Abp;
using Volo.Abp.MongoDB;

namespace FS.CmsKit.ContentDefinitions.MongoDB;

public static class ContentDefinitionsMongoDbContextExtensions
{
    public static void ConfigureContentDefinitions(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
