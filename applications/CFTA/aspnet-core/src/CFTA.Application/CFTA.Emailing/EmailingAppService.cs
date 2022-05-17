using FS.Abp.Emailing;
using System.Threading.Tasks;
using CFTA.Public.ContentDefinitions;
using Volo.Abp.Emailing;
using Volo.Abp.TextTemplating;
using Volo.Abp.Emailing.Templates;

namespace CFTA.Emailing
{
    public class EmailingAppService : CFTAAppService
    {
        private readonly EmailSenderManager emailSenderManager;
        private readonly IEmailSender _emailSender;
        private readonly ITemplateRenderer _templateRenderer;


        public EmailingAppService(
            FS.Abp.Emailing.EmailSenderManager emailSenderManager,
            IEmailSender emailSender,
             ITemplateRenderer templateRenderer
            )
        {
            this.emailSenderManager=emailSenderManager;
            _emailSender = emailSender;
            _templateRenderer = templateRenderer;
        }
        //FSEmailingManagement發信
        public async Task GetFsTestAsync()
        {
            await emailSenderManager.SendAsync("OrderPayEmail", new CFTA.Public.ContentDefinitions.Files.OrderPayEmailModel() { CompanyNameTitle = "臺南市臺灣鋼鐵俱樂部", LinkToWebSite = "https://tsgfc.com.tw" }, "changyenshung@gmail.com");
        }
        //直接發信

        public async Task GetAbpTestAsync() 
        {
            await _emailSender.SendAsync(
             "changyenshung@gmail.com",     // target email address
             "Email subject",         // subject
             "This is email body..."  // email body
         );
        }

        //樣板發信
        public async Task GetOrderPayMailAsync(string To ,string CompanyNameTitle = "臺南市臺灣鋼鐵俱樂部") 
        {
            var body = await _templateRenderer.RenderAsync(
             //StandardEmailTemplates.Message,
             "OrderPayEmail",
             new
             {
                 CompanyNameTitle = CompanyNameTitle,
             }
         );

            await _emailSender.SendAsync(
                To,
                CompanyNameTitle,
                body,
                true
            );
        }
    }
}
