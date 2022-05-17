using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace FS.Entity.Blazor.WebAssembly;

[DependsOn(
    typeof(EntityBlazorModule),
    typeof(EntityHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class EntityBlazorWebAssemblyModule : AbpModule
{

}
