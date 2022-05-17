using Volo.Abp.Bundling;

namespace FS.EcPay.Blazor.Host;

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
