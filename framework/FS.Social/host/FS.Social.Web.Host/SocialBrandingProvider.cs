using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace FS.Social;

[Dependency(ReplaceServices = true)]
public class SocialBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Social";
}
