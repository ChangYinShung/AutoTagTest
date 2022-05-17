using Volo.Abp.Bundling;

namespace FS.EShopManagement.Blazor.Host;

public class EShopManagementBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
