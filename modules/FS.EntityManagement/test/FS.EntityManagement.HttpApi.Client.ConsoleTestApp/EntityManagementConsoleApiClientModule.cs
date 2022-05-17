using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace FS.EntityManagement;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(EntityManagementHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class EntityManagementConsoleApiClientModule : AbpModule
{

}
