using TM.Files;
using Volo.Abp.TextTemplating;
using Volo.Abp.TextTemplating.Razor;

namespace TM
{
    public class DemoTemplateDefinitionProvider : TemplateDefinitionProvider
    {
        public override void Define(ITemplateDefinitionContext context)
        {
            context.Add(
                new TemplateDefinition("Hello") //template name: "Hello"
                    .WithRazorEngine()//.WithRazorEngine()
                    .WithVirtualFilePath(
                        "Files/Hello/Hello.cshtml", //template content path
                        isInlineLocalized: true
                    )
                    .WithProperty("ModelType", typeof(HelloModel))
            );
        }
    }
}
