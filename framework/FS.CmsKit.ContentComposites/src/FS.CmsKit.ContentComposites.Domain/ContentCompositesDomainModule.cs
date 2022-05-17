using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace FS.CmsKit.ContentComposites;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(ContentCompositesDomainSharedModule)
)]
[DependsOn(typeof(EasyAbp.Abp.Trees.AbpTreesDomainModule))]
[DependsOn(typeof(FS.CmsKit.CmsKitDomainModule))]
public class ContentCompositesDomainModule : AbpModule
{

}
