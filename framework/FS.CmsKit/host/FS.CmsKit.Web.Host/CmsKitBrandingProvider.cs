using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace FS.CmsKit;

[Dependency(ReplaceServices = true)]
public class CmsKitBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CmsKit";
}
