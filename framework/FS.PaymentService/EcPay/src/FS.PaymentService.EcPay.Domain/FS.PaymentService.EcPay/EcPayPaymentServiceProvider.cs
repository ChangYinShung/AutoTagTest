using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyAbp.PaymentService.Payments;
using EasyAbp.PaymentService.Refunds;
using FS.EcPay.HttpClient;
using FS.EcPay.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Volo.Abp.Data;
using Volo.Abp.Uow;

namespace FS.PaymentService.EcPay
{
    public class EcPayPaymentServiceProvider : PaymentServiceProvider
	{
		private readonly IEcPayHttpClient _ecPayHttpClient;

		private readonly IPaymentManager _paymentManager;
		private readonly IPaymentRepository _paymentRepository;

        private PaymentServiceOptions _paymentServiceOptions;

        public const string PaymentMethod = "EcPay";

		public EcPayPaymentServiceProvider(
			IEcPayHttpClient ecPayHttpClient,
			IPaymentManager paymentManager,
			IPaymentRepository paymentRepository,
            IOptions<PaymentServiceOptions> paymentServiceOptions
            )
		{
			_ecPayHttpClient = ecPayHttpClient;
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
			var ecPayProperty = payment.GetExtraProperty<EcPayPaymentExtraProperty>("EcPay");
			var itemNames = ecPayProperty?.ItemNames == null || ecPayProperty.ItemNames.Count() == 0 ?
				new List<string>() { "總計" } :
				ecPayProperty.ItemNames;


			var result = await this._ecPayHttpClient.CreatePaymentAsync(
				this._paymentServiceOptions.PostPayUrl,
				new CreatePayment()
				{
					PaymentId = payment.Id.ToString(),
					PaymentNo = paymentNo,
					Description = $"{paymentNo} 總計 {payment.ActualPaymentAmount}",
					PaymentDate = DateTime.Now,
					Amount = (int)payment.ActualPaymentAmount,
					ItemNames = itemNames
				});

			payment.SetProperty("HttpUrl", result);

			await _paymentRepository.UpdateAsync(payment);
		}

		public override async Task OnCancelStartedAsync(EasyAbp.PaymentService.Payments.Payment payment)
		{
			var paymentNo = payment.GetProperty<string>("PaymentNo");
			var ecPayPaymentNo = payment.GetProperty<string>("EcPayPaymentNo");

			await this._ecPayHttpClient.RefundPaymentAsync(new RefundPayment()
			{
				PaymentNo = paymentNo,
				EcPayPaymentNo = ecPayPaymentNo,
				Amount = (int)payment.ActualPaymentAmount
			});

			await _paymentManager.CompleteCancelAsync(payment);
		}

		public override async Task OnRefundStartedAsync(EasyAbp.PaymentService.Payments.Payment payment, Refund refund)
		{
			// 高銀退款
			var paymentNo = payment.GetProperty<string>("PaymentNo");
			var ecPayPaymentNo = payment.GetProperty<string>("EcPayPaymentNo");

			await this._ecPayHttpClient.RefundPaymentAsync(new RefundPayment()
			{
				PaymentNo = paymentNo,
				EcPayPaymentNo = ecPayPaymentNo,
				Amount = (int)refund.RefundAmount
			});

			// 金流退款完成
			await _paymentManager.CompleteRefundAsync(payment, refund);
		}
	}
}
