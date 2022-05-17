using Volo.Abp;
using Volo.Abp.MongoDB;

namespace FS.PaymentService.MongoDB;

public static class PaymentServiceMongoDbContextExtensions
{
    public static void ConfigurePaymentService(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
