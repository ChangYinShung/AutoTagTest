using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace FS.Abp.AspNetCore.Mvc.UI.Theme.Unice.Themes.Unice.Components.PageLayout
{
    public class PageLayoutScriptViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            
            return View(ViewBag.PageLayoutScript??"Default.cshtml");
        }
    }
}
