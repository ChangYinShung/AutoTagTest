using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace FS.CmsKit.ContentDefinitions.Blazor.WebAssembly;

[DependsOn(
    typeof(ContentDefinitionsBlazorModule),
    typeof(ContentDefinitionsHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class ContentDefinitionsBlazorWebAssemblyModule : AbpModule
{

}
