using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FS.SocialManagement.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class SocialManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "SocialManagement";
}
