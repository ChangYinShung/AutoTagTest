using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace FS.UnifyTheme.Pages
{
    public class IndexModel : UnifyThemePageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}