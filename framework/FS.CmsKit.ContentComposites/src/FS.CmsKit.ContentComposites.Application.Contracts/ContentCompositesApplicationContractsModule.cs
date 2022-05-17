using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace FS.CmsKit.ContentComposites;

[DependsOn(typeof(FS.CmsKit.CmsKitApplicationContractsModule))]
[DependsOn(typeof(ContentCompositesDomainSharedModule))]
public class ContentCompositesApplicationContractsModule : AbpModule
{

}
