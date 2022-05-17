using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace FS.CmsKit.ContentComposites;

[Dependency(ReplaceServices = true)]
public class ContentCompositesBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ContentComposites";
}
