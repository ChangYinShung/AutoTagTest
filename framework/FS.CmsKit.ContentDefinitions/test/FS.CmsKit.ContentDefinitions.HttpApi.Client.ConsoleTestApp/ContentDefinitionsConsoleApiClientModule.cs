using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace FS.CmsKit.ContentDefinitions;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ContentDefinitionsHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class ContentDefinitionsConsoleApiClientModule : AbpModule
{

}
