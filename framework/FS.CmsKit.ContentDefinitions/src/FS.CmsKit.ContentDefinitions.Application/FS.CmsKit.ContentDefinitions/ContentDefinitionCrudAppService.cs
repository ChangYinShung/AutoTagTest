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
    public partial class ContentDefinitionCrudAppService { }
    namespace V1
    {
        public partial class ContentDefinitionCrudAppService :
        Volo.Abp.Application.Services.CrudAppService<
            FS.CmsKit.ContentDefinitions.ContentDefinition,
            FS.CmsKit.ContentDefinitions.Dtos.V1.ContentDefinitionWithDetailsDto,
            FS.CmsKit.ContentDefinitions.Dtos.ContentDefinitionDto,
            Guid,
            FS.CmsKit.ContentDefinitions.Dtos.ContentDefinitionGetListDto,
            FS.CmsKit.ContentDefinitions.Dtos.ContentDefinitionCreateDto,
            FS.CmsKit.ContentDefinitions.Dtos.ContentDefinitionUpdateDto>,
        V1.IContentDefinitionCrudAppService
        {
            protected MediatR.IMediator Mediator => this.LazyServiceProvider.LazyGetRequiredService<MediatR.IMediator>();

            private readonly IContentDefinitionRepository _repository;

            public ContentDefinitionCrudAppService(IContentDefinitionRepository repository) : base(repository)
            {
                this._repository = repository;
            }

            protected override async Task<IQueryable<ContentDefinition>> CreateFilteredQueryAsync(ContentDefinitionGetListDto input)
            {
                return await this._repository.WithDetailsAsync();
            }
            public override async Task<Dtos.V1.ContentDefinitionWithDetailsDto> CreateAsync(ContentDefinitionCreateDto input)
            {
                var entity = await Mediator.Send(new FS.CmsKit.ContentDefinitionsMediator.V1.CreateContentDefinition()
                {
                    Version=input.Version
                });

                await this.Repository.InsertAsync(entity);

                return await base.MapToGetOutputDtoAsync(entity);
            }
        }
    }

}
