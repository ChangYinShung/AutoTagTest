using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace FS.UnifyTheme
{
    [DependsOn(
        typeof(UnifyThemeDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class UnifyThemeApplicationContractsModule : AbpModule
    {

    }
}
