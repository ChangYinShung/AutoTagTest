using System.Threading.Tasks;

namespace FS.LineNotify.HttpClient
{
    public interface ILineNotifyHttpClient
    {
        Task<string> AuthorizeUrlAsync(string state);
        Task NotifyAsync(string accessToken, string message);
        Task<GetTokenResult> TokenAsync(string code);
    }
}