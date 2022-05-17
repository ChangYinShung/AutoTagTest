using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace FS.CmsKit.ContentDefinitions
{
    namespace V1
    {
        public partial interface IContentTypeDefinitionCrudAppService :
            Volo.Abp.Application.Services.IReadOnlyAppService<
                FS.CmsKit.ContentDefinitions.Dtos.ContentTypeDefinitionWithDetailsDto,
                FS.CmsKit.ContentDefinitions.Dtos.ContentTypeDefinitionDto,
                Guid,
                FS.CmsKit.ContentDefinitions.Dtos.ContentTypeDefinitionGetListDto>,
            Volo.Abp.Application.Services.IDeleteAppService<Guid>
        {
            Task<Dtos.ContentTypeDefinitionWithDetailsDto> PatchAsync(Dtos.V1.ContentTypeDefinitionPatchDto input);
        }
    }


}
