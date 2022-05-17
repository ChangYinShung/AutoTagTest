using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace FS.CmsKit.ContentComposites.Blazor.WebAssembly;

[DependsOn(
    typeof(ContentCompositesBlazorModule),
    typeof(ContentCompositesHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class ContentCompositesBlazorWebAssemblyModule : AbpModule
{

}
