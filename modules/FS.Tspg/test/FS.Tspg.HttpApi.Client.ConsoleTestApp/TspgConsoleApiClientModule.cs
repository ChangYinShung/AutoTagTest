using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace FS.Tspg;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(TspgHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class TspgConsoleApiClientModule : AbpModule
{

}
