using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace FS.Tspg;

[Dependency(ReplaceServices = true)]
public class TspgBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Tspg";
}
