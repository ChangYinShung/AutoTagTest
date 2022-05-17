using Volo.Abp;
using Volo.Abp.MongoDB;

namespace FS.FormManagement.MongoDB;

public static class FormManagementMongoDbContextExtensions
{
    public static void ConfigureFormManagement(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
