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

namespace FS.Entity.EntityDefaults
{
    public partial class EntityDefaultItemCrudAppService :  // auto-generated
        Volo.Abp.Application.Services.CrudAppService<
            FS.Entity.EntityDefaults.EntityDefaultItem, 
            FS.Entity.EntityDefaults.Dtos.EntityDefaultItemWithDetailsDto, 
            FS.Entity.EntityDefaults.Dtos.EntityDefaultItemDto, 
            Guid, 
            FS.Entity.EntityDefaults.Dtos.EntityDefaultItemGetListDto, 
            FS.Entity.EntityDefaults.Dtos.EntityDefaultItemCreateDto, 
            FS.Entity.EntityDefaults.Dtos.EntityDefaultItemUpdateDto>,
        IEntityDefaultItemCrudAppService
    {
        private readonly IEntityDefaultItemRepository _repository;

        public EntityDefaultItemCrudAppService(IEntityDefaultItemRepository repository) : base(repository)
        {
            this._repository = repository;
        }
    }
}
