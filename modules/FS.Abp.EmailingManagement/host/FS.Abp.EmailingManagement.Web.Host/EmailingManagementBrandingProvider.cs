using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace FS.Abp.EmailingManagement;

[Dependency(ReplaceServices = true)]
public class EmailingManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "EmailingManagement";
}
