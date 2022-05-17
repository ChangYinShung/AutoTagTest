using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace FS.Abp.AspNetCore.Mvc.UI.Theme.Unice.Themes.Unice.Components.PageLayout
{
    public class PageLayoutStyleViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View(ViewBag.PageLayoutStyle??"Default.cshtml");
        }
    }
}
