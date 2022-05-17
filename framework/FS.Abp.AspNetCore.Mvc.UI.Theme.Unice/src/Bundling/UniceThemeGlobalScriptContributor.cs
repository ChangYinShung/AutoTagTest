using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace FS.Abp.AspNetCore.Mvc.UI.Theme.Unice.Bundling;

public class UniceThemeGlobalScriptContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.Add("/themes/unice/assets/js/popper.min.js");
        context.Files.Add("/themes/unice/assets/js/vanilla-tilt.min.js");
        context.Files.Add("/themes/unice/assets/js/aos.js");
        context.Files.Add("/themes/unice/assets/js/magnific-popup.js");
        context.Files.Add("/themes/unice/assets/js/owl.carousel.min.js");
    }
}
