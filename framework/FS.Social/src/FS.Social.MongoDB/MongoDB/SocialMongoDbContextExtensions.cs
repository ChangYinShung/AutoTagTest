using Volo.Abp;
using Volo.Abp.MongoDB;

namespace FS.Social.MongoDB;

public static class SocialMongoDbContextExtensions
{
    public static void ConfigureSocial(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
