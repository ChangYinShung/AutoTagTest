using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace FS.Abp.EmailingManagement.Blazor.WebAssembly;

[DependsOn(
    typeof(EmailingManagementBlazorModule),
    typeof(EmailingManagementHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class EmailingManagementBlazorWebAssemblyModule : AbpModule
{

}
