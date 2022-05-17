using Volo.Abp;
using Volo.Abp.MongoDB;

namespace FS.Tspg.MongoDB;

public static class TspgMongoDbContextExtensions
{
    public static void ConfigureTspg(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
