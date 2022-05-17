using FS.Payment.Tspg.Pages.Payment.Tspg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Volo.Payment.Requests;
using FS.Tspg.HttpClient;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Volo.Payment;

namespace FS.Payment.Tspg.Web.Pages.Payment.Tspg
{
    // IgnoreAntiforgery fix AntiforgeryValidationException
    // Order �� > 1000�A�Ѧ� https://github.com/aspnet/Mvc/issues/7012
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class PostPaymentModel : PageModel
    {
        private readonly PaymentWebOptions paymentWebOptions;
        private readonly IPaymentRequestAppService paymentRequestAppService;

        public PostPaymentModel(
            //IOptions<TspgOptions> tspgOptions,
            IOptions<PaymentWebOptions> paymentWebOptions,
            IPaymentRequestAppService paymentRequestAppService
            //IPurchaseParameterListGenerator purchaseParameterListGenerator
            )
        {
            this.paymentWebOptions = paymentWebOptions.Value;
            this.paymentRequestAppService = paymentRequestAppService;
        }

        public virtual IActionResult OnGet()
        {
            var paymentId = ViewData["PaymentId"];
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
            var isSuccess = result["ret_code"] == "00";
            if (!isSuccess) return BadRequest();

            var payment = await this.paymentRequestAppService.GetAsync(new Guid(paymentId));
            if (payment.State != PaymentRequestState.Waiting) return BadRequest();

            await this.paymentRequestAppService.CompleteAsync(new CompletePaymentRequestDto()
            {
                GateWay = TspgConsts.GatewayName,
                Id = payment.Id,
                ExtraProperties =
                {
                    { "PaymentNo", result["order_no"] },
                    { "AuthIdResp", result["auth_id_resp"] }
                }
            });

            return Redirect(this.paymentWebOptions.CallbackUrl);
        }
    }
}
