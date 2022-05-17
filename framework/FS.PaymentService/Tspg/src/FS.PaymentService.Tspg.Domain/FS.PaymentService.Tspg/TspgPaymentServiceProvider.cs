using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyAbp.PaymentService.Payments;
using EasyAbp.PaymentService.Refunds;
using FS.Tspg.HttpClient;
using FS.Tspg.HttpClient.Dtos;
using Microsoft.Extensions.Options;
using Volo.Abp.Data;
using Volo.Abp.Uow;

namespace FS.PaymentService.Tspg
{
    public class TspgPaymentServiceProvider : PaymentServiceProvider
    {
		private readonly ITspgHttpClient _tspgHttpClient;

		private readonly IPaymentManager _paymentManager;
		private readonly IPaymentRepository _paymentRepository;

		private PaymentServiceOptions _paymentServiceOptions;

		public const string PaymentMethod = "Tspg";

		public TspgPaymentServiceProvider(
			ITspgHttpClient tspgHttpClient,
			IPaymentManager paymentManager,
			IPaymentRepository paymentRepository,
			IOptions<PaymentServiceOptions> paymentServiceOptions)
		{
			_tspgHttpClient = tspgHttpClient;
			_paymentManager = paymentManager;
			_paymentRepository = paymentRepository;
			_paymentServiceOptions = paymentServiceOptions.Value;
		}

		[UnitOfWork(true)]
		public override async Task OnPaymentStartedAsync(EasyAbp.PaymentService.Payments.Payment payment, ExtraPropertyDictionary configurations)
		{
			if (payment.ActualPaymentAmount == decimal.Zero)
			{
				throw new PaymentAmountInvalidException(payment.ActualPaymentAmount, payment.PaymentMethod);
			}
			var paymentNo = payment.GetProperty<string>("PaymentNo") ?? DateTime.Now.ToString("yyyyMMddHHmmss");

			//TODO: WehHookUrl 讀設定值
			var input = new CreatePaymentRequest()
			{
				PaymentNo = paymentNo,
				Amount = payment.ActualPaymentAmount,
				Currency = payment.Currency,
				PostBackUrl = $"{_paymentServiceOptions.PostPayUrl}/{payment.Id}",
				PaymentId = payment.Id.ToString()
				//WehHookUrl= $"{_paymentServiceOptions.WebhookUrl}/{payment.Id}"
			};

			var result = await this._tspgHttpClient.CreatePaymentAsync(input);

			payment.SetProperty("HttpUrl", result.PaymentUrl);

			await _paymentRepository.UpdateAsync(payment);
		}

		public override async Task OnCancelStartedAsync(EasyAbp.PaymentService.Payments.Payment payment)
		{
			var paymentNo = payment.GetProperty<string>("PaymentNo");

			await this.RefundPaymentAsync(paymentNo, payment.ActualPaymentAmount);

			await _paymentManager.CompleteCancelAsync(payment);
		}

		public override async Task OnRefundStartedAsync(EasyAbp.PaymentService.Payments.Payment payment, Refund refund)
		{
			// 高銀退款
			var paymentNo = payment.GetProperty<string>("PaymentNo");

			await this.RefundPaymentAsync(paymentNo, refund.RefundAmount);

			// 金流退款完成
			await _paymentManager.CompleteRefundAsync(payment, refund);
		}

		private async Task RefundPaymentAsync(string paymentNo, decimal refundAmount)
        {
            {
				return;

				// 檢查銀行金流狀態，若已付款成功，則應退款
				var bankPayment = await GetBankPayment(paymentNo);
				
				// 金流未付款
				if (bankPayment == null) return;

				if (bankPayment.OrderStatus == "02")
				{
					if (refundAmount != bankPayment.TransactionAmount)
						throw new Exception("付款日不可部分退款");

					await this._tspgHttpClient.CancelPaymentAsync(new CancelPaymentRequest()
					{
						PaymentNo = paymentNo
					});
				}
				else
				{
					await this._tspgHttpClient.RefundPaymentAsync(new RefundPaymentRequest()
					{
						PaymentNo = paymentNo,
						RefundAmount = refundAmount
					});
				}
			}
            

            async Task<GetPaymentResult> GetBankPayment(string paymentNo)
            {
                try
                {
                    var bankPayment = await this._tspgHttpClient.GetPaymentAsync(new GetPaymentRequest()
                    {
                        PaymentNo = paymentNo
                    });

					return bankPayment;
				}
                catch (Exception ex)
                {
					//hong 若金流為未付款，則應跳過退款流程，直接取消金流。
					//     如為其他錯誤，則應丟出例外，停止金流取消流程，由人員判斷情況後處理
					//TODO:clinet 丟business exception來判斷是哪一種錯誤
					//throw new Exception("查詢訂單失敗，該筆訂單可能未完成付款", ex);
					return null;
                }
            }
        }
    }
}
