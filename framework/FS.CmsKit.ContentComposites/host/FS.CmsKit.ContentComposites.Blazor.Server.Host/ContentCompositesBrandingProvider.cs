using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FS.CmsKit.ContentComposites.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class ContentCompositesBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ContentComposites";
}
