using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FS.CmsKit.ContentDefinitions.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class ContentDefinitionsBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ContentDefinitions";
}
