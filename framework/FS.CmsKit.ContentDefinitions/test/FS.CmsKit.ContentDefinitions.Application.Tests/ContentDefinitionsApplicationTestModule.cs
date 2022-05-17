using Volo.Abp.Modularity;

namespace FS.CmsKit.ContentDefinitions;

[DependsOn(
    typeof(ContentDefinitionsApplicationModule),
    typeof(ContentDefinitionsDomainTestModule)
    )]
public class ContentDefinitionsApplicationTestModule : AbpModule
{

}
