using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.EventBus.Distributed;

namespace FS.Tspg;

public class TspgController : AbpControllerBase
{
    const string PaymentGateway = "Tspg";
    private readonly ILogger<TspgController> logger;
    private readonly IDistributedEventBus distributedEventBus;

    public TspgController(
        ILogger<TspgController> logger,
        IDistributedEventBus distributedEventBus)
    {
        this.logger=logger;
        this.distributedEventBus = distributedEventBus;
    }

    [HttpPost]
    [AllowAnonymous]
    [IgnoreAntiforgeryToken]
    [Route("api/tspg/call-back/{paymentId}")]
    public async Task CallBackAsync(string paymentId,[FromBody] JsonElement bankResponse)
    {
        var rawText = bankResponse.GetRawText();
        logger.LogInformation($"[TSPG]收到銀行Webhook");
        logger.LogInformation(rawText);

        var data = JsonSerializer.Deserialize<FS.Tspg.Dtos.CallBackDto>(bankResponse);

        var eto = ObjectMapper.Map<Dtos.CallBackDto, Etos.CallBackEto>(data);
        eto.PaymentGateway = PaymentGateway;
        eto.PaymentId = paymentId;

        await distributedEventBus.PublishAsync(eto);
    }
}
