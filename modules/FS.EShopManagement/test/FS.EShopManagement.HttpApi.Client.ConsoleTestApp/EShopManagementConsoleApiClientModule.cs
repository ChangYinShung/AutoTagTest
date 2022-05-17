using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace FS.EShopManagement;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(EShopManagementHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class EShopManagementConsoleApiClientModule : AbpModule
{

}
