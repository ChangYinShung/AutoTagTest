using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace FS.EcPay;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(EcPayHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class EcPayConsoleApiClientModule : AbpModule
{

}
