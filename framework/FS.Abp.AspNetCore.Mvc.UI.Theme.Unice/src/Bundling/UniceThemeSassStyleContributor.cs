using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace FS.Abp.AspNetCore.Mvc.UI.Theme.Unice.Bundling;

public class UniceThemeSassStyleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.Add("/themes/unice/assets/css/keyframes.css");
        context.Files.Add("/themes/unice/assets/css/swiper.min.css");
        context.Files.Add("/themes/unice/assets/css/aos.css");
        context.Files.Add("/themes/unice/assets/css/color-7.css");
    }
}
