using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace FS.EntityManagement.Blazor.WebAssembly;

[DependsOn(
    typeof(EntityManagementBlazorModule),
    typeof(EntityManagementHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class EntityManagementBlazorWebAssemblyModule : AbpModule
{

}
