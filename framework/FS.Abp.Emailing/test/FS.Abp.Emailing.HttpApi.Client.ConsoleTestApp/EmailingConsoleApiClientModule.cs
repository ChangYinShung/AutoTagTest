using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace FS.Abp.Emailing;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(EmailingHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class EmailingConsoleApiClientModule : AbpModule
{

}
