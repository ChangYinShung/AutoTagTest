using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace FS.Abp.Emailing.Blazor.WebAssembly;

[DependsOn(
    typeof(EmailingBlazorModule),
    typeof(EmailingHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class EmailingBlazorWebAssemblyModule : AbpModule
{

}
