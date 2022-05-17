using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace FS.UnifyTheme
{
    [DependsOn(
        typeof(UnifyThemeHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class UnifyThemeConsoleApiClientModule : AbpModule
    {
        
    }
}
