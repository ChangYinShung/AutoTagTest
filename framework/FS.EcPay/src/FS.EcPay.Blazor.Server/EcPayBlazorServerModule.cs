using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace FS.EcPay.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(EcPayBlazorModule)
    )]
public class EcPayBlazorServerModule : AbpModule
{

}
