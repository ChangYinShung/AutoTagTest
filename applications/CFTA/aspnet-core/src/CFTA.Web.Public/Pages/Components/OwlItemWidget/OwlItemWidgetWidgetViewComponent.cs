using Microsoft.AspNetCore.Mvc;
using System;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;


namespace CFTA.Web.Public.Components.OwlItemWidget
{
    [Widget]
    public class OwlItemWidgetViewComponent : AbpViewComponent
    {
        public OwlItemWidgetViewComponent()
        {

        }
        public IViewComponentResult Invoke(Guid? MediaId, string CssClass ,string Title, DisplayStyleEnum displayStyle,string LinkUrl)
        {
            return View(new OwlItemCountdownWidgetViewModel() { Title = Title,MediaId = MediaId, CssClass = CssClass,DisplayStyle = displayStyle,LinkUrl = LinkUrl});
        }
    }
}
