using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FS.CmsKit.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class CmsKitBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CmsKit";
}
