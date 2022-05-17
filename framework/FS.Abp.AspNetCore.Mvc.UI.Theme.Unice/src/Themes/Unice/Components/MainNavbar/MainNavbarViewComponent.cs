using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace FS.Abp.AspNetCore.Mvc.UI.Theme.Unice.Themes.Unice.Components.MainNavbar;

public class MainNavbarViewComponent : AbpViewComponent
{
    public virtual IViewComponentResult Invoke()
    {
        return View("~/Themes/Unice/Components/MainNavbar/Default.cshtml");
    }
}
