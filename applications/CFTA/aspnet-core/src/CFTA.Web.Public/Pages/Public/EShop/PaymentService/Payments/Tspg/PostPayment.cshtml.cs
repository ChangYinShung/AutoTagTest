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
    // Order �� > 1000�A�Ѧ� https://github.com/aspnet/Mvc/issues/7012
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
        /// �Ȧ�ɦ^��
        /// </summary>
        /// <param name="obj">
        /// s_mid ���S���N���A�Y����n�D�ɦ��ǤJ�A���a���ѼơC
        /// ret_code ������G
        /// tx_type ��������J1:���v 3:�д� 4:�����д� 5:�h�f 6:�����h�f(���p�dUnionPay �L���\��) 7:�d�� 8:�������v
        /// order_no �q�渹�X
        /// ret_msg �^�ǰT���A�D������
        /// auth_id_resp ���v�X�A���p�dUnionPay ����L���Ѽ�
        /// carrierId2 �H�Υd�����T�A�D������
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
