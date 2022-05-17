using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace FS.CmsKit.ContentDefinitions;

[DependsOn(typeof(FS.CmsKit.CmsKitApplicationContractsModule))]
[DependsOn(typeof(ContentDefinitionsDomainSharedModule))]
public class ContentDefinitionsApplicationContractsModule : AbpModule
{

}
