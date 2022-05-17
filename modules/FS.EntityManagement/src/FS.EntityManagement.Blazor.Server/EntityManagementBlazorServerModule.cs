using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace FS.EntityManagement.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(EntityManagementBlazorModule)
    )]
public class EntityManagementBlazorServerModule : AbpModule
{

}
