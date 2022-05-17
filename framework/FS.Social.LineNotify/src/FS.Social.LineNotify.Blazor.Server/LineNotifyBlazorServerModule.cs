using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace FS.Social.LineNotify.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(LineNotifyBlazorModule)
    )]
public class LineNotifyBlazorServerModule : AbpModule
{

}
