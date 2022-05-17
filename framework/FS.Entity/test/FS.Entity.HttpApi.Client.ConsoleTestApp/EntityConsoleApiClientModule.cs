using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace FS.Entity;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(EntityHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class EntityConsoleApiClientModule : AbpModule
{

}
