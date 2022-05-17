using Volo.Abp.Bundling;

namespace FS.Social.LineNotify.Blazor.Host;

public class LineNotifyBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
