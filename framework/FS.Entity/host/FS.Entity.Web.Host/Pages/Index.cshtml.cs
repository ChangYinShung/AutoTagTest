using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace FS.Entity.Pages;

public class IndexModel : EntityPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
