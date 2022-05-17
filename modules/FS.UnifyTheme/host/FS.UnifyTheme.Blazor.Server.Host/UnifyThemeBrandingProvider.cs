using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FS.UnifyTheme.Blazor.Server.Host
{
    [Dependency(ReplaceServices = true)]
    public class UnifyThemeBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "UnifyTheme";
    }
}
