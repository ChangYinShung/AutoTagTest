using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace FS.UnifyTheme
{
    [DependsOn(
        typeof(UnifyThemeApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class UnifyThemeHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "UnifyTheme";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(UnifyThemeApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
