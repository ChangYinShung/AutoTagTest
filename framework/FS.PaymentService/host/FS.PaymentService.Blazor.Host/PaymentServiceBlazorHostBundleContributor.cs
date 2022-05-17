using Volo.Abp.Bundling;

namespace FS.PaymentService.Blazor.Host;

public class PaymentServiceBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
