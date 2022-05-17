using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace FS.UnifyTheme.Blazor.Server
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsServerThemingModule),
        typeof(UnifyThemeBlazorModule)
        )]
    public class UnifyThemeBlazorServerModule : AbpModule
    {
        
    }
}