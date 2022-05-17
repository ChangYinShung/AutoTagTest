using EasyAbp.PaymentService.Payments;
using FS.EcPay.Etos;
using FS.PaymentService.Core.EventBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace FS.PaymentService.EcPay
{
    internal class CallBackHandler :
        IDistributedEventHandler<CallBackEto>,
        ITransientDependency
    {
        private const string PaymentGateway = "EcPay";
        private const string LogTitle = $"[PaymentService {PaymentGateway} {nameof(CallBackHandler)}]";

        private readonly IDistributedEventBus distributedEventBus;
        private readonly IPaymentRepository paymentRepository;
        private readonly ILogger<CallBackHandler> logger;

        public CallBackHandler(
            IDistributedEventBus distributedEventBus,
            IPaymentRepository paymentRepository,
            ILogger<CallBackHandler> logger)
        {
            this.distributedEventBus = distributedEventBus;
            this.paymentRepository = paymentRepository;
            this.logger = logger;
        }

        public async Task HandleEventAsync(CallBackEto eventData)
        {
            this.logger.LogInformation($"{LogTitle} {JsonConvert.SerializeObject(eventData)}");

            var paymentId = new Guid(eventData.PaymentId);

            var valid = await this.ValidPaymentIdAsync(paymentId);
            if (!valid)
            {
                this.logger.LogWarning($"{LogTitle} PaymentId {eventData.PaymentId} 不為 PaymentService 資料");
                return;
            }

            if (eventData.IsSuccess)
            {
                await this.distributedEventBus.PublishAsync(new PaymentSuccessEto()
                {
                    PaymentGateway = PaymentGateway,
                    PaymentId = paymentId,
                    PaymentNo = eventData.MerchantTradeNo
                });
            }
            else
            {
                await this.distributedEventBus.PublishAsync(new PaymentFailedEto()
                {
                    PaymentGateway = PaymentGateway,
                    PaymentId = paymentId,
                    PaymentNo = eventData.MerchantTradeNo,
                    Code = eventData.RtnCode?.ToString() ?? "",
                    Message = eventData.RtnMsg
                });
            }
        }

        /// <summary>
        /// 驗證 PaymentId 是否存在
        /// </summary>
        private async Task<bool> ValidPaymentIdAsync(Guid paymentId)
        {
            try
            {
                var payment = await this.paymentRepository.GetAsync(paymentId);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
