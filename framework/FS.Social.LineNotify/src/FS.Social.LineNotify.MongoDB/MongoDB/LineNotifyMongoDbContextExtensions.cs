using Volo.Abp;
using Volo.Abp.MongoDB;

namespace FS.Social.LineNotify.MongoDB;

public static class LineNotifyMongoDbContextExtensions
{
    public static void ConfigureLineNotify(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
