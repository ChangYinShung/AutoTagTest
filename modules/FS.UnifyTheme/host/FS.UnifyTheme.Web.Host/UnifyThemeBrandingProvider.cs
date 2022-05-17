using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace FS.UnifyTheme
{
    [Dependency(ReplaceServices = true)]
    public class UnifyThemeBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "UnifyTheme";
    }
}
