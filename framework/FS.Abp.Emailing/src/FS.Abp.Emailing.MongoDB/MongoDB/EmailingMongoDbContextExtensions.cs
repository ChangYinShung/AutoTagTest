using Volo.Abp;
using Volo.Abp.MongoDB;

namespace FS.Abp.Emailing.MongoDB;

public static class EmailingMongoDbContextExtensions
{
    public static void ConfigureEmailing(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
