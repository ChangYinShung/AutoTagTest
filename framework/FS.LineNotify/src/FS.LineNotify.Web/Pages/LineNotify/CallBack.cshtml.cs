using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Web;
using Volo.Abp.EventBus.Distributed;

namespace FS.LineNotify.Web.Pages.LineNotify;

[IgnoreAntiforgeryToken]
public class CallBackModel : LineNotifyPageModel
{
    private readonly IDistributedEventBus distributedEventBus;

    public CallBackModel(
        IDistributedEventBus distributedEventBus)
    {
        this.distributedEventBus=distributedEventBus;
    }
    public async Task OnGetAsync(string code, string state)
    {
        await distributedEventBus.PublishAsync(new Etos.LoginCallBackEto()
        {
            State = state,
            Code = code
        });
    }
}
