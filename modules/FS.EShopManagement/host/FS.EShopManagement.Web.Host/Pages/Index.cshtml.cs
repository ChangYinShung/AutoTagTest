using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace FS.EShopManagement.Pages;

public class IndexModel : EShopManagementPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
