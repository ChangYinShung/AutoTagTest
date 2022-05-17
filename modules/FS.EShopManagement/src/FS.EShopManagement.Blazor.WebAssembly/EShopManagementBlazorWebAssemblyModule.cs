using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace FS.EShopManagement.Blazor.WebAssembly;

[DependsOn(
    typeof(EShopManagementBlazorModule),
    typeof(EShopManagementHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class EShopManagementBlazorWebAssemblyModule : AbpModule
{

}
