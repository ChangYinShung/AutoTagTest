using Volo.Abp.Bundling;

namespace FS.CmsKit.ContentComposites.Blazor.Host;

public class ContentCompositesBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
