using Volo.Abp.Modularity;

namespace FS.CmsKit.ContentComposites;

[DependsOn(
    typeof(ContentCompositesApplicationModule),
    typeof(ContentCompositesDomainTestModule)
    )]
public class ContentCompositesApplicationTestModule : AbpModule
{

}
