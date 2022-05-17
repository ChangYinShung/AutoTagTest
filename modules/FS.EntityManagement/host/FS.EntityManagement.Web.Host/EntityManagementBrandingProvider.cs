using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace FS.EntityManagement;

[Dependency(ReplaceServices = true)]
public class EntityManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "EntityManagement";
}
