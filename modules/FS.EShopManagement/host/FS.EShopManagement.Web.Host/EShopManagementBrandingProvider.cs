using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace FS.EShopManagement;

[Dependency(ReplaceServices = true)]
public class EShopManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "EShopManagement";
}
