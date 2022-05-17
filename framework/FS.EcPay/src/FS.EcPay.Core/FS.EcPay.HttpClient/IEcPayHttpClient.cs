using System.Threading.Tasks;

namespace FS.EcPay.HttpClient
{
    public interface IEcPayHttpClient
    {
        Task<string> CreatePaymentAsync(string postPayUrl, CreatePayment input);
        Task<string> GetCreditTransactionAsync(GetCreditTransaction input);
        Task<GetPaymentResult> GetPaymentAsync(GetPayment input);
        Task<string> RefundPaymentAsync(RefundPayment input);
    }
}