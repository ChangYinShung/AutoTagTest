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

namespace FS.CmsKit.ContentDefinitions
{
    public partial class ContentDefinitionCrudAppService :  // auto-generated
        Volo.Abp.Application.Services.CrudAppService<
            FS.CmsKit.ContentDefinitions.ContentDefinition, 
            FS.CmsKit.ContentDefinitions.Dtos.ContentDefinitionWithDetailsDto, 
            FS.CmsKit.ContentDefinitions.Dtos.ContentDefinitionDto, 
            Guid, 
            FS.CmsKit.ContentDefinitions.Dtos.ContentDefinitionGetListDto, 
            FS.CmsKit.ContentDefinitions.Dtos.ContentDefinitionCreateDto, 
            FS.CmsKit.ContentDefinitions.Dtos.ContentDefinitionUpdateDto>,
        IContentDefinitionCrudAppService
    {
        private readonly IContentDefinitionRepository _repository;

        public ContentDefinitionCrudAppService(IContentDefinitionRepository repository) : base(repository)
        {
            this._repository = repository;
        }
    }
}
