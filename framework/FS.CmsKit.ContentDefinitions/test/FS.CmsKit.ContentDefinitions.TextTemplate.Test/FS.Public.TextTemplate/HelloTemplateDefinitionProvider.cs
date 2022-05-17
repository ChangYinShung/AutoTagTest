using FS.Public.TextTemplate.Files;
using Volo.Abp.TextTemplating;
using Volo.Abp.TextTemplating.Razor;

namespace FS.Public.TextTemplate
{
    public class HelloTemplateDefinitionProvider : TemplateDefinitionProvider
    {
        public override void Define(ITemplateDefinitionContext context)
        {
            context.Add(
                new TemplateDefinition("Hello") //template name: "Hello"
                    .WithRazorEngine()
                    .WithVirtualFilePath(
                        "Files/Hello.cshtml", //template content path
                        isInlineLocalized: true
                    )
                    .WithProperty("ModelType", typeof(HelloModel))
            );
        }
    }
}
