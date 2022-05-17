using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace FS.UnifyTheme.Blazor.WebAssembly
{
    [DependsOn(
        typeof(UnifyThemeBlazorModule),
        typeof(UnifyThemeHttpApiClientModule),
        typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
        )]
    public class UnifyThemeBlazorWebAssemblyModule : AbpModule
    {
        
    }
}