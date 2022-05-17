using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace FS.Social.LineNotify;

public class LineNotifyAppService : ILineNotifyAppService, Volo.Abp.DependencyInjection.ITransientDependency
{
    private readonly LineNotifyManager lineNotifyManager;

    public LineNotifyAppService(
        LineNotifyManager lineNotifyManager
        )
    {
        this.lineNotifyManager=lineNotifyManager;
    }
    public async Task<string> GetAuthorizeUrlAsync(string providerName = null, string providerKey = null)
    {
        return await lineNotifyManager.AuthorizeUrlAsync(providerName, providerKey);
    }

    public async Task PostNotifyAsync(string message, string providerName = null, string providerKey = null)
    {
        await lineNotifyManager.NotifyAsync(message, providerName, providerKey);
    }
}
