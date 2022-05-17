using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;
using Volo.Abp.Modularity;
using Volo.Abp.TextTemplating;
using Volo.Abp.Uow;
using Volo.Abp.VirtualFileSystem;

namespace FS.Abp.Emailing;

public class BackgroundEmailSendingJob : AsyncBackgroundJob<BackgroundEmailSendingJobArgs>, ITransientDependency
{
    private readonly IEmailingStore emailingStore;
    private readonly ITemplateDefinitionManager templateDefinitionManager;
    private readonly ITemplateRenderer templateRenderer;
    private readonly IEmailSender emailSender;

    public BackgroundEmailSendingJob(
        IEmailSender emailSender,
        FS.Abp.Emailing.IEmailingStore emailingStore,
        Volo.Abp.TextTemplating.ITemplateDefinitionManager templateDefinitionManager,
        ITemplateRenderer templateRenderer
        )
    {
        this.emailSender = emailSender;
        this.emailingStore=emailingStore;
        this.templateDefinitionManager=templateDefinitionManager;
        this.templateRenderer=templateRenderer;
    }

    [UnitOfWork]
    public override async Task ExecuteAsync(BackgroundEmailSendingJobArgs args)
    {
        var mailMessageTemplate = await this.emailingStore.MailMessageTemplate.GetAsync(x => x.No==args.MailMessageTemplateNo);

        var model = await emailingStore.GetAsync(args.MailMessageTemplateNo, args.CacheKey);

        var body = await templateRenderer.RenderAsync(args.MailMessageTemplateNo, model);

        string from="";
        string subject= "";
        List<string> ccs = new List<string>();
        List<string> bccs = new List<string>();

        var mailMessage = new System.Net.Mail.MailMessage(from, args.To)
        {
            Subject= subject,
            Body=body,
            IsBodyHtml=true,
        };

        ccs.ForEach(cc =>
        {
            mailMessage.CC.Add(cc); 
        });


        bccs.ForEach(bcc =>
        {
            mailMessage.Bcc.Add(bcc);
        });

        await emailSender.SendAsync(mailMessage);

    }
}
