using Volo.Abp.Bundling;

namespace FS.EntityManagement.Blazor.Host;

public class EntityManagementBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
