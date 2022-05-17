using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace FS.Social.Pages;

public class IndexModel : SocialPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
