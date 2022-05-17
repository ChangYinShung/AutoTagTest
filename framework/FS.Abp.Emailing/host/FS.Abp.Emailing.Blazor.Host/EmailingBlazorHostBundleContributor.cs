using Volo.Abp.Bundling;

namespace FS.Abp.Emailing.Blazor.Host;

public class EmailingBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
