using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace FS.EntityManagement.Pages;

public class IndexModel : EntityManagementPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
