using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace FS.SocialManagement;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SocialManagementHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class SocialManagementConsoleApiClientModule : AbpModule
{

}
