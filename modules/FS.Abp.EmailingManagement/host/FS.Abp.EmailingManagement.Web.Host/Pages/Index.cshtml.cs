using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace FS.Abp.EmailingManagement.Pages;

public class IndexModel : EmailingManagementPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
