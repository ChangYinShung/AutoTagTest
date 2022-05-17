using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FS.EntityManagement.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class EntityManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "EntityManagement";
}
