using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace FS.Payment.EcPay.Pages;

public class IndexModel : EcPayPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
