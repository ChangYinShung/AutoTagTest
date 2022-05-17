using Volo.Payment.Requests;

namespace FS.Payment.Tspg.Pages.Payment.Tspg;

public interface IPurchaseParameterListGenerator
{
    TspgPaymentRequestExtraParameterConfiguration GetExtraParameterConfiguration(
        PaymentRequestWithDetailsDto paymentRequest);
}
