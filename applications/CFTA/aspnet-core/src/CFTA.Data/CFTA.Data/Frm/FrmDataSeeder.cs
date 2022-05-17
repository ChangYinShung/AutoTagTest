using FS.Abp.Npoi.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Uow;
using Volo.Forms.Forms;

namespace CFTA.Data.Frm
{
    public class FrmDataSeeder : DomainService, Volo.Abp.DependencyInjection.ITransientDependency
    {
        private VirtualFileNpoiReader virtualFileNpoiReader => this.LazyServiceProvider.LazyGetRequiredService<VirtualFileNpoiReader>();
        private IUnitOfWorkManager UnitOfWorkManager => this.LazyServiceProvider.LazyGetRequiredService<IUnitOfWorkManager>();

        private IFormAppService FormAppService => this.LazyServiceProvider.LazyGetRequiredService<IFormAppService>();
        
        private IFormRepository FormRepository => this.LazyServiceProvider.LazyGetRequiredService<IFormRepository>();

        public async Task CreateFormsAsync()
        {
            var hasDatas = await this.FormRepository.GetCountAsync() > 0;
            if (hasDatas) return;

            var forms = this.virtualFileNpoiReader.Read<Files.Frm.Form>();
            var questions = this.virtualFileNpoiReader.Read<Files.Frm.Question>();
            var choices = this.virtualFileNpoiReader.Read<Files.Frm.Choice>();

            await forms.ForEachAsync(async (form) =>
            {
                FormDto formItem =  await this.FormAppService.CreateAsync(new CreateFormDto()
                {
                    Title = form.Title,
                    Description = form.Description
                });

                var formQuestions = questions.Where(x => x.FormNo == form.No).ToList();
                var formIndex = 0;
                await formQuestions.ForEachAsync(async (question) =>
                {
                    Enum.TryParse<Volo.Forms.QuestionTypes>(question.QuestionType, out var type);

                    await this.FormAppService.CreateQuestionAsync(formItem.Id, new Volo.Forms.Questions.CreateQuestionDto()
                    {
                        Index = formIndex,
                        Title = question.Title,
                        Description = question.Description,
                        IsRequired = question.IsRequired,
                        HasOtherOption = question.HasOtherOption,
                        QuestionType = type,
                        Choices = choices
                            .Where(x => x.QuestionNo == question.No)
                            .Select((x, choiceIndex) => new Volo.Forms.Choices.ChoiceDto()
                            {
                                Id = this.GuidGenerator.Create(),
                                Index = choiceIndex,
                                IsCorrect = false,
                                Value = x.Value
                            })
                            .ToList()
                    });

                    formIndex++;
                });
            });
        }
    }
}
