using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FS.EShopManagement.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class EShopManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "EShopManagement";
}
