using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace FS.CmsKit.ContentComposites.Pages;

public class IndexModel : ContentCompositesPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
