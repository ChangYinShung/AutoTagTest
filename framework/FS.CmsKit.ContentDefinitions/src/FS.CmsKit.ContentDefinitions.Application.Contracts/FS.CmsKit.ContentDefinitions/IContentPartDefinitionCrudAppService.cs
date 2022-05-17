using FS.CmsKit.ContentDefinitions.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace FS.CmsKit.ContentDefinitions
{
    namespace V1
    {
        public partial interface IContentPartDefinitionCrudAppService :
            Volo.Abp.Application.Services.IReadOnlyAppService<
                FS.CmsKit.ContentDefinitions.Dtos.ContentPartDefinitionWithDetailsDto,
                Guid,
                Dtos.ContentPartDefinitionGetListDto>,
            Volo.Abp.Application.Services.IDeleteAppService<Guid>
        {
            Task<ContentPartDefinitionWithDetailsDto> PatchAsync(Dtos.V1.ContentPartDefinitionPatchDto input);
        }
    }

}
