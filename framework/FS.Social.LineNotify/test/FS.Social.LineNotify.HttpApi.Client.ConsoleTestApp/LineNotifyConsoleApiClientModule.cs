﻿using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace FS.Social.LineNotify;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(LineNotifyHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class LineNotifyConsoleApiClientModule : AbpModule
{

}
