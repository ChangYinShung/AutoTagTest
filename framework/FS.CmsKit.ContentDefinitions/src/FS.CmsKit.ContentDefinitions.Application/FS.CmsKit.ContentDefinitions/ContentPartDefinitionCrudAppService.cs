using FS.CmsKit.ContentDefinitions.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace FS.CmsKit.ContentDefinitions
{
    [Volo.Abp.RemoteService(false)]
    public partial class ContentPartDefinitionCrudAppService { }

    namespace V1
    {
        public partial class ContentPartDefinitionCrudAppService :
            Volo.Abp.Application.Services.ReadOnlyAppService<
                FS.CmsKit.ContentDefinitions.ContentPartDefinition,
                FS.CmsKit.ContentDefinitions.Dtos.ContentPartDefinitionWithDetailsDto,
                Guid,
                FS.CmsKit.ContentDefinitions.Dtos.ContentPartDefinitionGetListDto>,
            V1.IContentPartDefinitionCrudAppService
        {
            protected MediatR.IMediator Mediator => this.LazyServiceProvider.LazyGetRequiredService<MediatR.IMediator>();

            private readonly IContentPartDefinitionRepository _repository;

            public ContentPartDefinitionCrudAppService(IContentPartDefinitionRepository repository) : base(repository)
            {
                this._repository = repository;
            }

            public async Task<ContentPartDefinitionWithDetailsDto> PatchAsync(Dtos.V1.ContentPartDefinitionPatchDto input)
            {
                var mediator = this.LazyServiceProvider.LazyGetService<MediatR.IMediator>();

                var patchCommand = new ContentDefinitionsMediator.V1.PatchContentPartDefinition()
                {
                    Name=input.Name,
                    ContentDefinitionId=input.ContentDefinitionId,
                    TemplateDefinitionName=input.TextTemplateContentName,
                    Type=input.Type
                };

                var entity = await mediator.Send(patchCommand);

                await this._repository.PatchAsync(entity);

                return await MapToGetOutputDtoAsync(entity);
            }

            public async Task DeleteAsync(Guid id)
            {
                await _repository.DeleteAsync(id);
            }
        }
    }

}
