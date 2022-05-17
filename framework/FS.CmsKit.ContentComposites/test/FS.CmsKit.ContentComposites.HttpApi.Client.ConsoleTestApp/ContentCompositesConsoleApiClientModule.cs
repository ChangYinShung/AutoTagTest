using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace FS.CmsKit.ContentComposites;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ContentCompositesHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class ContentCompositesConsoleApiClientModule : AbpModule
{

}
