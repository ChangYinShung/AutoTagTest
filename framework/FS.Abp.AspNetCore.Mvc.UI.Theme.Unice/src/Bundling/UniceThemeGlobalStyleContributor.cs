using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace FS.Abp.AspNetCore.Mvc.UI.Theme.Unice.Bundling;

public class UniceThemeGlobalStyleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.Add("/themes/unice/assets/css/owl.carousel.min.css");
        context.Files.Add("/themes/unice/assets/css/owl.theme.default.min.css");
        context.Files.Add("/themes/unice/assets/css/themify.css");
        context.Files.Add("/themes/unice/assets/css/flaticon.css");
        context.Files.Add("/themes/unice/assets/css/magnific-popup.css");
    }
}
