using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace FS.SocialManagement.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(SocialManagementBlazorModule)
    )]
public class SocialManagementBlazorServerModule : AbpModule
{

}
