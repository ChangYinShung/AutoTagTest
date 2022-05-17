using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace FS.PaymentService.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(PaymentServiceBlazorModule)
    )]
public class PaymentServiceBlazorServerModule : AbpModule
{

}
