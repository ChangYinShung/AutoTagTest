using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Data;
using Volo.Abp.EventBus.Distributed;

namespace FS.PaymentService.EcPay
{
    // IgnoreAntiforgery fix AntiforgeryValidationException
    // Order 需 > 1000，參考 https://github.com/aspnet/Mvc/issues/7012
    [IgnoreAntiforgeryToken(Order = 1001)]
    [AllowAnonymous]
    public class PostPaymentModel : PageModel
    {
        private const string PaymentGateway = "EcPay";

        private readonly EasyAbp.PaymentService.Payments.PaymentAppService eshopPaymentAppService;
        private readonly FS.EcPay.HttpClient.EcPayHttpClient ecPayHttpClient;
        private readonly IDistributedEventBus distributedEventBus;

        public PostPaymentModel(
            EasyAbp.PaymentService.Payments.PaymentAppService eshopPaymentAppService,
            FS.EcPay.HttpClient.EcPayHttpClient ecPayHttpClient,
            IDistributedEventBus distributedEventBus
            )
        {
            this.eshopPaymentAppService = eshopPaymentAppService;
            this.ecPayHttpClient = ecPayHttpClient;
            this.distributedEventBus = distributedEventBus;
        }

        public virtual async Task<IActionResult> OnGetAsync(string paymentId)
        {
            var id = new Guid(paymentId);
            var payment = await this.eshopPaymentAppService.GetAsync(id);

            var paymentNo = payment.GetProperty<string>("PaymentNo");
            var bankPayment = await this.ecPayHttpClient.GetPaymentAsync(new FS.EcPay.HttpClient.GetPayment()
            {
                Date = DateTime.Now,
                PaymentNo = paymentNo
            });

            if (!bankPayment.IsSuccess)
            {
                await this.distributedEventBus.PublishAsync(new Core.EventBus.PaymentFailedEto()
                {
                    PaymentGateway = PaymentGateway,
                    PaymentId = id,
                    PaymentNo = paymentNo,
                    Code = "0",
                    Message = "銀行交易失敗"
                });
                return Redirect($"/e-shop/payment-service/payment-fail/銀行交易失敗");
            }

            await this.distributedEventBus.PublishAsync(new Core.EventBus.PaymentSuccessEto()
            {
                PaymentGateway = PaymentGateway,
                PaymentId = id,
                PaymentNo = paymentNo
            });
            return Redirect("/e-shop/payment-service/payment-success");
        }
    }
}
