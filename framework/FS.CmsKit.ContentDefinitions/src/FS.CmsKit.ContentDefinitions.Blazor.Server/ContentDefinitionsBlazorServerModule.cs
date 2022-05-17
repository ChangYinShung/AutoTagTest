using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace FS.CmsKit.ContentDefinitions.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(ContentDefinitionsBlazorModule)
    )]
public class ContentDefinitionsBlazorServerModule : AbpModule
{

}
