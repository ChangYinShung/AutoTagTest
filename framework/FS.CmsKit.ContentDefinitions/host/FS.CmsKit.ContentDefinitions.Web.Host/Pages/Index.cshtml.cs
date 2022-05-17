using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace FS.CmsKit.ContentDefinitions.Pages;

public class IndexModel : ContentDefinitionsPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
