//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by YinChang.
// 5.1.3
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace FS.CmsKit.ContentComposites
{
    public partial class ContentComponentCrudAppService :  // auto-generated
        Volo.Abp.Application.Services.CrudAppService<
            FS.CmsKit.ContentComposites.ContentComponent, 
            FS.CmsKit.ContentComposites.Dtos.ContentComponentWithDetailsDto, 
            FS.CmsKit.ContentComposites.Dtos.ContentComponentDto, 
            Guid, 
            FS.CmsKit.ContentComposites.Dtos.ContentComponentGetListDto, 
            FS.CmsKit.ContentComposites.Dtos.ContentComponentCreateDto, 
            FS.CmsKit.ContentComposites.Dtos.ContentComponentUpdateDto>,
        IContentComponentCrudAppService
    {
        private readonly IContentComponentTreeRepository _repository;

        public ContentComponentCrudAppService(IContentComponentTreeRepository repository) : base(repository)
        {
            this._repository = repository;
        }
    }
}
