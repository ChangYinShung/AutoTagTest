using Volo.Abp.Bundling;

namespace FS.CmsKit.ContentDefinitions.Blazor.Host;

public class ContentDefinitionsBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
