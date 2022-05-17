using Volo.Abp.Bundling;

namespace FS.FormManagement.Blazor.Host;

public class FormManagementBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
