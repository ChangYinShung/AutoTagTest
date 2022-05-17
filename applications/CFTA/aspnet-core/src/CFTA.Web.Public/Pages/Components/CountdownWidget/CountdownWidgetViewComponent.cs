using Microsoft.AspNetCore.Mvc;
using System;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.JQuery;


namespace CFTA.Web.Public.Components.CountdownWidget
{
    [Widget(
        StyleFiles = new[] { "/Pages/Components/CountdownWidget/Default.css" },
        ScriptFiles = new[] { "/Pages/Components/CountdownWidget/Default.js" }
      )]
    public class CountdownWidgetViewComponent : AbpViewComponent
    {
        public CountdownWidgetViewComponent()
        {

        }
        public IViewComponentResult Invoke(string Title,string Content,string LogoUrl)
        {
            return View( new CountdownWidgetViewModel() { Title = Title,Content = Content,LogoUrl = LogoUrl});
        }
    }
}
