using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace FS.PaymentService.Blazor.WebAssembly;

[DependsOn(
    typeof(PaymentServiceBlazorModule),
    typeof(PaymentServiceHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class PaymentServiceBlazorWebAssemblyModule : AbpModule
{

}
