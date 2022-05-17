using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace FS.UnifyTheme
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(UnifyThemeDomainSharedModule)
    )]
    public class UnifyThemeDomainModule : AbpModule
    {

    }
}
