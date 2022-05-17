using Volo.Abp.Bundling;

namespace FS.Payment.EcPay.Blazor.Host;

public class EcPayBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
