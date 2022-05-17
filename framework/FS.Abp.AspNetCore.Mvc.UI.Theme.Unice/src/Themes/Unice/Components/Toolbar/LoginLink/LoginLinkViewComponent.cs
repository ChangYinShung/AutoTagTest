using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace FS.Abp.AspNetCore.Mvc.UI.Theme.Unice.Themes.Unice.Components.Toolbar.LoginLink;

public class LoginLinkViewComponent : AbpViewComponent
{
    public virtual IViewComponentResult Invoke()
    {
        return View("~/Themes/Unice/Components/Toolbar/LoginLink/Default.cshtml");
    }
}
