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
    internal class PaymentFailedHandler :
        IDistributedEventHandler<PaymentFailedEto>,
        ITransientDependency
    {
        private ILogger<PaymentFailedHandler> logger;

        public PaymentFailedHandler(
            ILogger<PaymentFailedHandler> logger)
        {
            this.logger = logger;
        }

        public async Task HandleEventAsync(PaymentFailedEto eventData)
        {
            this.logger.LogInformation($"[PaymentFailedHandler]金流付款失敗 {eventData.PaymentNo}");
            this.logger.LogInformation($"{JsonConvert.SerializeObject(eventData)}");
        }
    }
}
