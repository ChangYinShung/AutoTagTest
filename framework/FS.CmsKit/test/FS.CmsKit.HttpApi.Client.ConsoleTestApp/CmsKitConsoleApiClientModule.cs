using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace FS.CmsKit;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CmsKitHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class CmsKitConsoleApiClientModule : AbpModule
{

}
