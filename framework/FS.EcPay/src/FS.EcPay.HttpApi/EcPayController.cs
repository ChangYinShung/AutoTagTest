using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.EventBus.Distributed;

namespace FS.EcPay
{
    public class EcPayController : AbpControllerBase
    {

        private readonly ILogger<EcPayController> logger;
        private readonly IDistributedEventBus distributedEventBus;

        public EcPayController(
            ILogger<EcPayController> logger,
            IDistributedEventBus distributedEventBus)
        {
            this.logger = logger;
            this.distributedEventBus = distributedEventBus;
        }

        [HttpPost]
        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [Route("api/ec-pay/call-back/{paymentId}")]
        public async Task CallBackAsync(string paymentId, Dtos.CallBackDto paramters)
        {
            logger.LogInformation($"[EcPay]收到銀行Webhook");
            logger.LogInformation(JsonSerializer.Serialize(paramters));
            logger.LogInformation($"paymentId: {paymentId}");

            var eto = ObjectMapper.Map<Dtos.CallBackDto, Etos.CallBackEto>(paramters);
            eto.PaymentId = paymentId;

            await distributedEventBus.PublishAsync(eto);
        }
    }
}
