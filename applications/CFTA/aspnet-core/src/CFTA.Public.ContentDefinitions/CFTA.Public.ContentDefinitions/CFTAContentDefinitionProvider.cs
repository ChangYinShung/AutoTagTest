using CFTA.Public.ContentDefinitions.Files;
using Volo.Abp.TextTemplating;
using Volo.Abp.TextTemplating.Razor;

namespace CFTA.Public.ContentDefinitions
{
    public class CFTAContentDefinitionProvider : TemplateDefinitionProvider
    {
        public override void Define(ITemplateDefinitionContext context)
        {
            context.Add(
                new TemplateDefinition("AboutUs")
                    .WithRazorEngine()
                    .WithVirtualFilePath(
                        "/Files/AboutUs.cshtml", //template content path
                        isInlineLocalized: true
                    )
                    .WithProperty("ModelType", typeof(AboutUsModel))
            );
            context.Add(
                new TemplateDefinition("Countdown")
                    .WithRazorEngine()
                    .WithVirtualFilePath(
                        "/Files/Countdown.cshtml", //template content path
                        isInlineLocalized: true
                    )
                    .WithProperty("ModelType", typeof(CountdownModel))
            );
            context.Add(
            new TemplateDefinition("Footer")
                .WithRazorEngine()
                .WithVirtualFilePath(
                    "/Files/Footer.cshtml", //template content path
                    isInlineLocalized: true
                )
                .WithProperty("ModelType", typeof(FooterModel))
            );


            //TODO:樣板要改成適用MutiTenant
            var orderPayEmail = new TemplateDefinition("OrderPayEmail")
                //.WithRazorEngine()
                .WithVirtualFilePath(
                    "/Files/OrderPayEmail.tpl", //template content path
                    isInlineLocalized: true
                );
            //.WithProperty("ModelType", typeof(OrderPayEmailModel));
            orderPayEmail.Layout = "Abp.StandardEmailTemplates.Layout";
            context.Add(orderPayEmail);
        }
    }
}
