using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.VeeValidate;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.Vue;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace CFTA.Web.Public.Pages.Components.ProductCartWidget
{
    [Widget(
        StyleFiles = new[]
        {
            "/Pages/Components/ProductCartWidget/Default.css"
        },
        ScriptTypes = new[]
        {
            typeof(VueScriptContributor),
            typeof(VeeValidateScriptContributor),
            typeof(ProductCartWidgetScriptContributor)
        }
    )]
    public class ProductCartWidgetViewComponent : AbpViewComponent
    {
        public virtual IViewComponentResult Invoke()
        {
            return View();
        }
    }

    public class ProductCartWidgetScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.Add("/Pages/Components/ProductCartWidget/Default.js");
        }
    }
}
