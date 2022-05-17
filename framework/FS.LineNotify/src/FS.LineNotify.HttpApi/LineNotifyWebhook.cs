using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Web;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.EventBus.Distributed;

namespace FS.LineNotify.Webhook
{
    [RemoteService]
    [Route("webhook/line-notify")]
    public class LineNotifyWebhook : AbpController
    {
        private readonly IDistributedEventBus _distributedEventBus;

        public LineNotifyWebhook(
            IDistributedEventBus distributedEventBus
            )
        {
            //LocalizationResource = typeof(LineNotifyResource);
            _distributedEventBus = distributedEventBus;
        }

        [HttpGet]
        [Route("call-back")]
        public async Task<ActionResult> CallBackAsync(string code, string state)
        {
            var parameters = HttpUtility.ParseQueryString(state);

            await _distributedEventBus.PublishAsync(new Etos.LoginCallBackEto()
            {
                State=state,
                Code = code
            });

            return Content("Line Notify 連結已完成，請關閉此頁");
        }

    }
}
