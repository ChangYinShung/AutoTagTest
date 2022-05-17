using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace FS.CmsKit.Blazor.WebAssembly;

[DependsOn(
    typeof(CmsKitBlazorModule),
    typeof(CmsKitHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class CmsKitBlazorWebAssemblyModule : AbpModule
{

}
