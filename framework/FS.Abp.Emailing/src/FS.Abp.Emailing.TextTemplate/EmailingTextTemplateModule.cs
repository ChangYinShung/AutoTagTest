using Microsoft.CodeAnalysis;
using Volo.Abp.Modularity;
using Volo.Abp.TextTemplating.Razor;
using Volo.Abp.VirtualFileSystem;

namespace FS.Abp.Emailing.TextTemplate;

[DependsOn(typeof(Volo.Abp.TextTemplating.Razor.AbpTextTemplatingRazorModule))]
public class EmailingTextTemplateModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<EmailingTextTemplateModule>();
        });

        Configure<AbpRazorTemplateCSharpCompilerOptions>(options =>
        {
            options.References.Add(MetadataReference.CreateFromFile(typeof(EmailingTextTemplateModule).Assembly.Location));
        });
    }
}
