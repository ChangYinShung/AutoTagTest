using Volo.Abp;
using Volo.Abp.MongoDB;

namespace FS.Abp.EmailingManagement.MongoDB;

public static class EmailingManagementMongoDbContextExtensions
{
    public static void ConfigureEmailingManagement(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
