using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace FS.Social.LineNotify;

public interface ILineNotifyAppService : IApplicationService
{
    Task<string> GetAuthorizeUrlAsync(string providerName = null, string providerKey = null);

    Task PostNotifyAsync(string message, string providerName = null, string providerKey = null);
}
