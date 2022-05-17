using Volo.Abp.Modularity;

namespace FS.UnifyTheme
{
    [DependsOn(
        typeof(UnifyThemeApplicationModule),
        typeof(UnifyThemeDomainTestModule)
        )]
    public class UnifyThemeApplicationTestModule : AbpModule
    {

    }
}
