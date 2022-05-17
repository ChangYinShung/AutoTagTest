using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Uow;
using Volo.Abp.TextTemplateManagement.TextTemplates;
using FS.Abp.Npoi.Mapper;
using FS.Abp.Emailing;

namespace CFTA.Data.TextTemplate
{
    public class TemplateDataSeeder : DomainService
    {
        private ITextTemplateContentRepository TemplateContentRepository => this.LazyServiceProvider.LazyGetRequiredService<ITextTemplateContentRepository>();
        private ITemplateContentAppService TemplateContentAppService => this.LazyServiceProvider.LazyGetRequiredService<ITemplateContentAppService>();
        private ITemplateDefinitionAppService TemplateDefinitionAppService=> this.LazyServiceProvider.LazyGetRequiredService<ITemplateDefinitionAppService>();
        private IMailMessageTemplateRepository MailMessageTemplateRepository => this.LazyServiceProvider.LazyGetRequiredService<IMailMessageTemplateRepository>();


        private VirtualFileNpoiReader virtualFileNpoiReader => this.LazyServiceProvider.LazyGetRequiredService<VirtualFileNpoiReader>();
        [UnitOfWork]
        public virtual async Task UpdateTemplateAsync(Guid? tenantId = null)
        {

            using (CurrentTenant.Change(tenantId))
            {

                //var template = new MailMessageTemplate() { 
                //    DisplayName = "OrderPayMail",
                //    No = "OrderPayMail",
                //    TenantId = tenantId,
                //    CacheKey= "OrderPayMail",
                //    Title = "臺南臺灣鋼鐵足球俱樂部-訂單完成",
                //};
                //await MailMessageTemplateRepository.InsertAsync(template);


                var templateContents = this.virtualFileNpoiReader.Read<Files.TextTemplate.TemplateContent>();
                var dbData = await TemplateContentRepository.FindAsync(templateContents.First().TemplateName);
                if (dbData != null) return;
                await templateContents.ForEachAsync((templateContent) =>
                TemplateContentAppService.UpdateAsync(new UpdateTemplateContentInput()
                {
                    Content = templateContent.Content,
                    CultureName = templateContent.CultureName,
                    TemplateName = templateContent.TemplateName
                }));
            }
        }
    }
}
