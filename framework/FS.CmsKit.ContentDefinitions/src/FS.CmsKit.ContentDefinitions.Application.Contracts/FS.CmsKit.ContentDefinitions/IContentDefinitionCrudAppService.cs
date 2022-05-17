
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Services;

namespace FS.CmsKit.ContentDefinitions
{
    namespace V1
    {
        public partial interface IContentDefinitionCrudAppService :
          Volo.Abp.Application.Services.ICrudAppService<
              FS.CmsKit.ContentDefinitions.Dtos.V1.ContentDefinitionWithDetailsDto,
              FS.CmsKit.ContentDefinitions.Dtos.ContentDefinitionDto,
              Guid,
              FS.CmsKit.ContentDefinitions.Dtos.ContentDefinitionGetListDto,
              FS.CmsKit.ContentDefinitions.Dtos.ContentDefinitionCreateDto,
              FS.CmsKit.ContentDefinitions.Dtos.ContentDefinitionUpdateDto>
        {

        }
    }

}
