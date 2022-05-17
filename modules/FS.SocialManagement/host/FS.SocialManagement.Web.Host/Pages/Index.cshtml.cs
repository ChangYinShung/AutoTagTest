using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace FS.SocialManagement.Pages;

public class IndexModel : SocialManagementPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
