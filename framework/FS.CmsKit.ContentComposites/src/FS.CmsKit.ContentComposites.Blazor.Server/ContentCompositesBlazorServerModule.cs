using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace FS.CmsKit.ContentComposites.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(ContentCompositesBlazorModule)
    )]
public class ContentCompositesBlazorServerModule : AbpModule
{

}
