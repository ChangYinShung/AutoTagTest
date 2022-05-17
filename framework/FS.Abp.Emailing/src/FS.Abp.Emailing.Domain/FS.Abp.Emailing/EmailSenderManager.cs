using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;
using Volo.Abp.Guids;

namespace FS.Abp.Emailing
{
    public class EmailSenderManager : ITransientDependency
    {
        private readonly IGuidGenerator guidGenerator;
        private readonly IEmailingStore emailingStore;
        private readonly IBackgroundJobManager backgroundJobManager;

        public EmailSenderManager(
            IGuidGenerator guidGenerator,
            IEmailingStore emailingStore,
            IBackgroundJobManager backgroundJobManager)
        {
            this.guidGenerator=guidGenerator;
            this.emailingStore=emailingStore;
            this.backgroundJobManager=backgroundJobManager;
        }


        public async Task SendAsync(string no, object model,string to)
        {
            var id = guidGenerator.Create().ToString();

            await emailingStore.SetAsync(no, id, model);

            await backgroundJobManager.EnqueueAsync(
                new BackgroundEmailSendingJobArgs()
                {
                    CacheKey=id,
                    MailMessageTemplateNo=no,
                    To=to
                }
            );
        }
    }
}
