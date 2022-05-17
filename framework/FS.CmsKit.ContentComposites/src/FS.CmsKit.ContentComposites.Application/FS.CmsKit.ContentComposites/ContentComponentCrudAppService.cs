using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace FS.CmsKit.ContentComposites
{
    [Volo.Abp.RemoteService(false)]
    public partial class ContentComponentCrudAppService { }
    namespace V1
    {
        
        public partial class ContentComponentCrudAppService :
            Volo.Abp.Application.Services.ReadOnlyAppService<
                FS.CmsKit.ContentComposites.ContentComponent,
                FS.CmsKit.ContentComposites.Dtos.ContentComponentWithDetailsDto,
                FS.CmsKit.ContentComposites.Dtos.ContentComponentDto,
                Guid,
                FS.CmsKit.ContentComposites.Dtos.ContentComponentGetListDto>,
            IContentComponentCrudAppService
        {
            private readonly IContentComponentTreeRepository _repository;

            public ContentComponentCrudAppService(IContentComponentTreeRepository repository) : base(repository)
            {
                this._repository = repository;
            }
            public Task<Dtos.ContentComponentWithDetailsDto> PatchAsync(Dtos.V1.ContentComponentPatchDto input)
            {
                return null;
            }

            public async Task DeleteAsync(Guid id)
            {
                await this._repository.DeleteAsync(id);
            }
        }
    }

}
