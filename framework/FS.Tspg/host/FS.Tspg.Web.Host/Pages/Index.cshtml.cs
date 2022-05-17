using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace FS.Tspg.Pages;

public class IndexModel : TspgPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
