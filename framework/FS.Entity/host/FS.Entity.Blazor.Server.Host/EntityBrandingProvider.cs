using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FS.Entity.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class EntityBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Entity";
}
