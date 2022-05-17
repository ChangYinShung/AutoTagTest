using System;
using System.Collections.Generic;
using Volo.Abp.Application.Services;

namespace FS.CmsKit.ContentComposites
{
    namespace V1 
    {
        public partial interface IContentComponentCrudAppService :
            Volo.Abp.Application.Services.IReadOnlyAppService<
                FS.CmsKit.ContentComposites.Dtos.ContentComponentWithDetailsDto,
                FS.CmsKit.ContentComposites.Dtos.ContentComponentDto,
                Guid,
                FS.CmsKit.ContentComposites.Dtos.ContentComponentGetListDto>,
            Volo.Abp.Application.Services.IDeleteAppService<Guid>
        {

        }
    }

}
