﻿using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace FS.Social.LineNotify.Blazor.WebAssembly;

[DependsOn(
    typeof(LineNotifyBlazorModule),
    typeof(LineNotifyHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class LineNotifyBlazorWebAssemblyModule : AbpModule
{

}
