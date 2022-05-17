using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace FS.Abp.EmailingManagement.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(EmailingManagementBlazorModule)
    )]
public class EmailingManagementBlazorServerModule : AbpModule
{

}
