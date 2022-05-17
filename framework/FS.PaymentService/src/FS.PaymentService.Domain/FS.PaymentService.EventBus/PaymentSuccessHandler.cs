using FS.PaymentService.Core.EventBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace FS.PaymentService.EventBus
{
    internal class PaymentSuccessHandler :
        IDistributedEventHandler<PaymentSuccessEto>,
        ITransientDependency
    {
        private EasyAbp.PaymentService.Payments.IPaymentManager paymentsManager;
        private EasyAbp.PaymentService.Payments.IPaymentRepository paymentsRepository;
        private ILogger<PaymentSuccessHandler> logger;


        public PaymentSuccessHandler(
            EasyAbp.PaymentService.Payments.IPaymentManager paymentsManager,
            EasyAbp.PaymentService.Payments.IPaymentRepository paymentsRepository,
            ILogger<PaymentSuccessHandler> logger)
        {
            this.paymentsManager = paymentsManager;
            this.paymentsRepository = paymentsRepository;
            this.logger = logger;
        }

        public async Task HandleEventAsync(PaymentSuccessEto eventData)
        {
            this.logger.LogInformation($"[PaymentSuccessHandler]金流付款成功 {eventData.PaymentNo}");
            this.logger.LogInformation($"{JsonConvert.SerializeObject(eventData)}");

            var payment = await this.paymentsRepository.GetAsync(eventData.PaymentId);

            // 已取消或已完成之 Payment 則不再執行付款完成 api
            if (!payment.IsInProgress())
            {
                this.logger.LogInformation($"[PaymentSuccessHandler]{eventData.PaymentNo} 金流狀態為已取消或已完成，事件結束");
                return;
            }

            await this.paymentsManager.CompletePaymentAsync(payment);
            this.logger.LogInformation($"[PaymentSuccessHandler]{eventData.PaymentNo} 金流付款完成，事件結束");
        }
    }
}
