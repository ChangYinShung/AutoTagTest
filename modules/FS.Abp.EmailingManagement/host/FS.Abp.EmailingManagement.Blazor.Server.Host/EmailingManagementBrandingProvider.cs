using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FS.Abp.EmailingManagement.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class EmailingManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "EmailingManagement";
}
