using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace FS.EcPay;

[Dependency(ReplaceServices = true)]
public class EcPayBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "EcPay";
}
