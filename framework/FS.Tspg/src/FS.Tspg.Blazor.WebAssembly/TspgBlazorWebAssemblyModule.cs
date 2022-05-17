using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace FS.Tspg.Blazor.WebAssembly;

[DependsOn(
    typeof(TspgBlazorModule),
    typeof(TspgHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class TspgBlazorWebAssemblyModule : AbpModule
{

}
