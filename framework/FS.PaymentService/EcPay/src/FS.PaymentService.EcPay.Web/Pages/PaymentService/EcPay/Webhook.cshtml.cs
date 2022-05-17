using FS.EcPay;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace FS.PaymentService.EcPay
{
    // IgnoreAntiforgery fix AntiforgeryValidationException
    // Order »Ý > 1000¡A°Ñ¦Ò https://github.com/aspnet/Mvc/issues/7012
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class WebhookModel : PageModel
    {
        public string paymentId { get; set; }

        public readonly EcPayController ecPayController;

        public WebhookModel(EcPayController ecPayWebHookController)
        {
            this.ecPayController = ecPayWebHookController;
        }

        public async Task OnPostAsync(string paymentId, FS.EcPay.Dtos.CallBackDto paramters)
        {
            this.paymentId = paymentId;
            await this.ecPayController.CallBackAsync(paymentId, paramters);
        }
    }
}
