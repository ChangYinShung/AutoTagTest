using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace FS.Abp.AspNetCore.Mvc.UI.Theme.Unice.Bundling;

public class UniceThemeSassScriptContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.Add("/themes/unice/assets/js/main.js");
        context.Files.Add("/themes/unice/assets/js/video-popup.js");
        context.Files.Add("/themes/unice/assets/js/layout-fix.js");
        context.Files.Add("/themes/unice/assets/js/script8.js");

    }
}
