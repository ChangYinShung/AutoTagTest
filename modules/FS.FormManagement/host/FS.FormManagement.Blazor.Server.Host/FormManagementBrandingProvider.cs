using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FS.FormManagement.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class FormManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "FormManagement";
}
