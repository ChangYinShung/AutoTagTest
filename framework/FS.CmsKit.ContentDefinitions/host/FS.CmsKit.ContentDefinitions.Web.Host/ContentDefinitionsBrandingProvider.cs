using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace FS.CmsKit.ContentDefinitions;

[Dependency(ReplaceServices = true)]
public class ContentDefinitionsBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ContentDefinitions";
}
