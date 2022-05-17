using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace FS.SocialManagement.Blazor.WebAssembly;

[DependsOn(
    typeof(SocialManagementBlazorModule),
    typeof(SocialManagementHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class SocialManagementBlazorWebAssemblyModule : AbpModule
{

}
