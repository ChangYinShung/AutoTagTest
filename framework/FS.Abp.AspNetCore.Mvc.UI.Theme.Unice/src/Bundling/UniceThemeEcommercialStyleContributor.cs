using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace FS.Abp.AspNetCore.Mvc.UI.Theme.Unice.Bundling;

public class UniceThemeEcommercialStyleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.Add("/themes/unice/assets/css/color-7.css");
    }
}
