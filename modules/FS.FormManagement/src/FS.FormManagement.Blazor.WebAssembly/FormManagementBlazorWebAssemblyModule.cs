using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace FS.FormManagement.Blazor.WebAssembly;

[DependsOn(
    typeof(FormManagementBlazorModule),
    typeof(FormManagementHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class FormManagementBlazorWebAssemblyModule : AbpModule
{

}
