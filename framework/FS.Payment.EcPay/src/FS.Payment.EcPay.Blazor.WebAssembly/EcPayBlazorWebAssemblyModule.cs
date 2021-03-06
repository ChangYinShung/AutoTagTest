using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace FS.Payment.EcPay.Blazor.WebAssembly;

[DependsOn(
    typeof(EcPayBlazorModule),
    typeof(EcPayHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class EcPayBlazorWebAssemblyModule : AbpModule
{

}
