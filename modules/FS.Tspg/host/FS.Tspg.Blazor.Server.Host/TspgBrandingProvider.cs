using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FS.Tspg.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class TspgBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Tspg";
}
