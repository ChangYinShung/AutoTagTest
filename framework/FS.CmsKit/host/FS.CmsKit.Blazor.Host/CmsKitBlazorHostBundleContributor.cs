using Volo.Abp.Bundling;

namespace FS.CmsKit.Blazor.Host;

public class CmsKitBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
