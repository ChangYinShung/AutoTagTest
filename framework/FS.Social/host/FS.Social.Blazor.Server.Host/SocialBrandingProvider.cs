using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FS.Social.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class SocialBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Social";
}
