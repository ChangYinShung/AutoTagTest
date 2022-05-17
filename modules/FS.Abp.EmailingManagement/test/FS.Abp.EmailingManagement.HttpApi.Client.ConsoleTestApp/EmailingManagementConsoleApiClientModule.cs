using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace FS.Abp.EmailingManagement;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(EmailingManagementHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class EmailingManagementConsoleApiClientModule : AbpModule
{

}
