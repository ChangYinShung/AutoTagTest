using Volo.Abp.Bundling;

namespace FS.UnifyTheme.Blazor.Host
{
    public class UnifyThemeBlazorHostBundleContributor : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {

        }

        public void AddStyles(BundleContext context)
        {
            context.Add("main.css", true);
        }
    }
}
