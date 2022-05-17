using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FS.EcPay.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class EcPayBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "EcPay";
}
