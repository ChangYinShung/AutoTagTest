using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FS.PaymentService.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class PaymentServiceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "PaymentService";
}
