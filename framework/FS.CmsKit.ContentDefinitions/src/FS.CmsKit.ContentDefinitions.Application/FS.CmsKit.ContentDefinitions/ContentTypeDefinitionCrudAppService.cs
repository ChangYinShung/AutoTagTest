using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace FS.CmsKit.ContentDefinitions
{
    [Volo.Abp.RemoteService(false)]
    public partial class ContentTypeDefinitionCrudAppService { }
    namespace V1
    {
        public partial class ContentTypeDefinitionCrudAppService :
            Volo.Abp.Application.Services.ReadOnlyAppService<
                FS.CmsKit.ContentDefinitions.ContentTypeDefinition,
                FS.CmsKit.ContentDefinitions.Dtos.ContentTypeDefinitionWithDetailsDto,
                FS.CmsKit.ContentDefinitions.Dtos.ContentTypeDefinitionDto,
                Guid, FS.CmsKit.ContentDefinitions.Dtos.ContentTypeDefinitionGetListDto>,
            IContentTypeDefinitionCrudAppService
        {

            protected MediatR.IMediator Mediator => this.LazyServiceProvider.LazyGetRequiredService<MediatR.IMediator>();

            private readonly IContentTypeDefinitionRepository _repository;

            public ContentTypeDefinitionCrudAppService(IContentTypeDefinitionRepository repository) : base(repository)
            {
                this._repository = repository;
            }

            public async Task<Dtos.ContentTypeDefinitionWithDetailsDto> PatchAsync(Dtos.V1.ContentTypeDefinitionPatchDto input)
            {
                var mediator = this.LazyServiceProvider.LazyGetService<MediatR.IMediator>();

                var patchCommand = new ContentDefinitionsMediator.V1.PatchContentTypeDefinition()
                {
                    ContentDefinitionId=input.ContentDefinitionId,
                    ContentPartDefinitionIds=input.ContentPartDefinitionIds,
                    EntityId=input.EntityId,
                    EntityType=input.EntityType
                };

                var entity = await mediator.Send(patchCommand);

                await this._repository.PatchAsync(entity);

                return await MapToGetOutputDtoAsync(entity);
            }

            public async Task DeleteAsync(Guid id)
            {
                await this._repository.DeleteAsync(id);
            }
        }
    }

}
