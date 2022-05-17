using Volo.Abp.Bundling;

namespace FS.Tspg.Blazor.Host;

public class TspgBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
