using Volo.Abp.Bundling;

namespace FS.Social.Blazor.Host;

public class SocialBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
