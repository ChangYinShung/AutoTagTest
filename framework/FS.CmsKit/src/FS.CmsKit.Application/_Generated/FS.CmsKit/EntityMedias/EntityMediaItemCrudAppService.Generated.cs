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

namespace FS.CmsKit.EntityMedias
{
    public partial class EntityMediaItemCrudAppService :  // auto-generated
        Volo.Abp.Application.Services.CrudAppService<
            FS.CmsKit.EntityMedias.EntityMediaItem, 
            FS.CmsKit.EntityMedias.Dtos.EntityMediaItemWithDetailsDto, 
            FS.CmsKit.EntityMedias.Dtos.EntityMediaItemDto, 
            Guid, 
            FS.CmsKit.EntityMedias.Dtos.EntityMediaItemGetListDto, 
            FS.CmsKit.EntityMedias.Dtos.EntityMediaItemCreateDto, 
            FS.CmsKit.EntityMedias.Dtos.EntityMediaItemUpdateDto>,
        IEntityMediaItemCrudAppService
    {
        private readonly IEntityMediaItemRepository _repository;

        public EntityMediaItemCrudAppService(IEntityMediaItemRepository repository) : base(repository)
        {
            this._repository = repository;
        }
    }
}
