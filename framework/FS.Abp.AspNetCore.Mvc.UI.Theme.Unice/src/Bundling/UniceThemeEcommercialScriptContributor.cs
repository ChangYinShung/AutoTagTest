using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace FS.Abp.AspNetCore.Mvc.UI.Theme.Unice.Bundling;

public class UniceThemeEcommercialScriptContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.Add("/themes/unice/assets/js/isotope.min.js");
        context.Files.Add("/themes/unice/assets/js/portfolio.js");
        context.Files.Add("/themes/unice/assets/js/main.js");
        context.Files.Add("/themes/unice/assets/js/ecommerce.js");
    }
}
