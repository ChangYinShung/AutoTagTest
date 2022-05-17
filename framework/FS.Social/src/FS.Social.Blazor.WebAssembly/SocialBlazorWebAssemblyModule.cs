using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace FS.Social.Blazor.WebAssembly;

[DependsOn(
    typeof(SocialBlazorModule),
    typeof(SocialHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class SocialBlazorWebAssemblyModule : AbpModule
{

}
