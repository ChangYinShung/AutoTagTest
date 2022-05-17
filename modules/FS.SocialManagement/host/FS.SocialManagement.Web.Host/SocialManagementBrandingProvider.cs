using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace FS.SocialManagement;

[Dependency(ReplaceServices = true)]
public class SocialManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "SocialManagement";
}
