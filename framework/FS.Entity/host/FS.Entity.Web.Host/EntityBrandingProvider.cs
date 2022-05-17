using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace FS.Entity;

[Dependency(ReplaceServices = true)]
public class EntityBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Entity";
}
