using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Volo.Payment.Requests;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Volo.Payment;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Data;
using Volo.Abp.EventBus.Distributed;

namespace CFTA.Pages.EShop.PaymentService.Payments.EcPay
{
    // IgnoreAntiforgery fix AntiforgeryValidationException
    // Order 需 > 1000，參考 https://github.com/aspnet/Mvc/issues/7012
    [IgnoreAntiforgeryToken(Order = 1001)]
    [AllowAnonymous]
    public class PostPaymentModel : PageModel
    {
        private readonly EasyAbp.EShop.Payments.Payments.PaymentAppService eshopPaymentAppService;
        private readonly FS.EcPay.HttpClient.EcPayHttpClient ecPayHttpClient;
        private readonly IDistributedEventBus distributedEventBus;

        public PostPaymentModel(
            EasyAbp.EShop.Payments.Payments.PaymentAppService eshopPaymentAppService,
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
                await this.distributedEventBus.PublishAsync(new FS.Payment.Core.Events.PaymentFailedEto()
                {
                    PaymentGateway = "EShop",
                    PaymentId = id,
                    PaymentNo = paymentNo,
                    Code = "0",
                    Message = "銀行交易失敗"
                });
                return Redirect($"/e-shop/payment-service/payment-fail/銀行交易失敗");
            }

            await this.distributedEventBus.PublishAsync(new FS.Payment.Core.Events.PaymentSuccessEto()
            {
                PaymentGateway = "EShop",
                PaymentId = id,
                PaymentNo = paymentNo
            });
            return Redirect("/e-shop/payment-service/payment-success");
        }
    }
}
