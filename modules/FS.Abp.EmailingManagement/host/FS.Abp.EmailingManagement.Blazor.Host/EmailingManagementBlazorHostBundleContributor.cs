using Volo.Abp.Bundling;

namespace FS.Abp.EmailingManagement.Blazor.Host;

public class EmailingManagementBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
