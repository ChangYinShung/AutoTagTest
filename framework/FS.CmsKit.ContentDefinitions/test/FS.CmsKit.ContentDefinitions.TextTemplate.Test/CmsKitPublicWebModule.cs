using Microsoft.CodeAnalysis;
using Volo.Abp.Modularity;
using Volo.Abp.TextTemplating.Razor;
using Volo.Abp.VirtualFileSystem;

namespace FS.CmsKit.ContentDefinitions.TextTemplate;

[DependsOn(
    typeof(Volo.Abp.TextTemplating.Razor.AbpTextTemplatingRazorModule)
)]
public class ContentDefinitionsTextTemplateTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpRazorTemplateCSharpCompilerOptions>(options =>
        {
            options.References.Add(MetadataReference.CreateFromFile(typeof(ContentDefinitionsTextTemplateTestModule).Assembly.Location));
        });

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ContentDefinitionsTextTemplateTestModule>();
        });
    }
}
