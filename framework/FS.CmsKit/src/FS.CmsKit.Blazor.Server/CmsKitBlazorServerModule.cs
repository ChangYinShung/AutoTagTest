using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace FS.CmsKit.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(CmsKitBlazorModule)
    )]
public class CmsKitBlazorServerModule : AbpModule
{

}
