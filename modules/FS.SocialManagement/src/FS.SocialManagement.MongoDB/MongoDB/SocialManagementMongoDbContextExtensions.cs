using Volo.Abp;
using Volo.Abp.MongoDB;

namespace FS.SocialManagement.MongoDB;

public static class SocialManagementMongoDbContextExtensions
{
    public static void ConfigureSocialManagement(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
