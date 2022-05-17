using FS.Tspg.HttpClient.Dtos;
using System.Threading.Tasks;

namespace FS.Tspg.HttpClient
{
    public interface ITspgHttpClient
    {
        Task<CancelPaymentResult> CancelPaymentAsync(CancelPaymentRequest input);
        Task<CreatePaymentResult> CreatePaymentAsync(CreatePaymentRequest input);
        Task<GetPaymentResult> GetPaymentAsync(GetPaymentRequest input);
        Task<RefundPaymentResult> RefundPaymentAsync(RefundPaymentRequest input);
    }
}