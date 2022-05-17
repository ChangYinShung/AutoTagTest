using Microsoft.AspNetCore.Mvc;
using System;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;


namespace CFTA.Web.Public.Components.CoverImageWidget
{
    [Widget]
    public class CoverImageWidgetViewComponent : AbpViewComponent
    {
        public CoverImageWidgetViewComponent()
        {

        }
        public IViewComponentResult Invoke(Guid? MediaId, string CssClass)
        {
            ViewBag.MediaId = MediaId;
            ViewBag.CssClass = CssClass;

            return View();
        }
    }
}
