using Volo.Abp;
using Volo.Abp.MongoDB;

namespace FS.Payment.EcPay.MongoDB;

public static class EcPayMongoDbContextExtensions
{
    public static void ConfigureEcPay(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
