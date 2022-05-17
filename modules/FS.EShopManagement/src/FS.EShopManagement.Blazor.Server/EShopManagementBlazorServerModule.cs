using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace FS.EShopManagement.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(EShopManagementBlazorModule)
    )]
public class EShopManagementBlazorServerModule : AbpModule
{

}
