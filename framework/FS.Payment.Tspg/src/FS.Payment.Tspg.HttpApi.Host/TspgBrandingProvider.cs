using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FS.Payment.Tspg;

[Dependency(ReplaceServices = true)]
public class TspgBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Tspg";
}
