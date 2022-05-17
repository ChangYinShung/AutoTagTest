using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Volo.Payment.Requests;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Volo.Payment;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.EventBus.Distributed;

namespace CFTA.Pages.EShop.PaymentService.Payments.Tspg
{
    // IgnoreAntiforgery fix AntiforgeryValidationException
    // Order 需 > 1000，參考 https://github.com/aspnet/Mvc/issues/7012
    [IgnoreAntiforgeryToken(Order = 1001)]
    [AllowAnonymous]
    public class PostPaymentModel : PageModel
    {
        //private readonly PaymentWebOptions paymentWebOptions;

        private readonly IDistributedEventBus distributedEventBus;

        public PostPaymentModel(
            //IOptions<PaymentWebOptions> paymentWebOptions,
            IDistributedEventBus distributedEventBus
            )
        {
            //this.paymentWebOptions = paymentWebOptions.Value;
            this.distributedEventBus = distributedEventBus;
        }

        public virtual IActionResult OnGet()
        {
            return BadRequest();
        }

        /// <summary>
        /// 銀行導回頁
        /// </summary>
        /// <param name="obj">
        /// s_mid 次特店代號，若交易要求時有傳入，必帶此參數。
        /// ret_code 交易結果
        /// tx_type 交易類型︰1:授權 3:請款 4:取消請款 5:退貨 6:取消退貨(銀聯卡UnionPay 無此功能) 7:查詢 8:取消授權
        /// order_no 訂單號碼
        /// ret_msg 回傳訊息，非必有值
        /// auth_id_resp 授權碼，銀聯卡UnionPay 交易無此參數
        /// carrierId2 信用卡載具資訊，非必有值
        /// </param>
        public async Task<IActionResult> OnPost(string paymentId, Dictionary<string, string> result)
        {
            var id = new Guid(paymentId);
            var resultCode = result["ret_code"];
            var errorMessage = result["ret_msg"];
            var paymentNo = result["order_no"];
            var isSuccess = result["ret_code"] == "00";

            if (!isSuccess)
            {
                await this.distributedEventBus.PublishAsync(new FS.Payment.Core.Events.PaymentFailedEto()
                {
                    PaymentGateway = "Tspg",
                    PaymentId = id,
                    PaymentNo = paymentNo,
                    Code = resultCode,
                    Message = errorMessage
                });
                return Redirect($"/e-shop/payment-service/payment-fail/{errorMessage}");
            }

            await this.distributedEventBus.PublishAsync(new FS.Payment.Core.Events.PaymentSuccessEto()
            {
                PaymentGateway = "Tspg",
                PaymentId = id,
                PaymentNo = paymentNo
            });

            return Redirect("/e-shop/payment-service/payment-success");
        }
    }
}
