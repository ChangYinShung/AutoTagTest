using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace FS.CmsKit.ContentDefinitions;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(ContentDefinitionsDomainSharedModule)
)]
[DependsOn(typeof(FS.CmsKit.CmsKitDomainModule))]
[DependsOn(typeof(Volo.Abp.TextTemplating.AbpTextTemplatingCoreModule))]
[DependsOn(typeof(FS.Entity.EntityFeatures.EntityFeaturesDomainModule))]
public class ContentDefinitionsDomainModule : AbpModule
{

}
