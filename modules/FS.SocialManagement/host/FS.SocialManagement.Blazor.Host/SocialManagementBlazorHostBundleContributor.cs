using Volo.Abp.Bundling;

namespace FS.SocialManagement.Blazor.Host;

public class SocialManagementBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
