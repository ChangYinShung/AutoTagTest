﻿//------------------------------------------------------------------------------
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

namespace FS.Entity.MultiLinguals
{
    public partial class MultiLingualTranslationCrudAppService :  // auto-generated
        Volo.Abp.Application.Services.CrudAppService<
            FS.Entity.MultiLinguals.MultiLingualTranslation, 
            FS.Entity.MultiLinguals.Dtos.MultiLingualTranslationWithDetailsDto, 
            FS.Entity.MultiLinguals.Dtos.MultiLingualTranslationDto, 
            Guid, 
            FS.Entity.MultiLinguals.Dtos.MultiLingualTranslationGetListDto, 
            FS.Entity.MultiLinguals.Dtos.MultiLingualTranslationCreateDto, 
            FS.Entity.MultiLinguals.Dtos.MultiLingualTranslationUpdateDto>,
        IMultiLingualTranslationCrudAppService
    {
        private readonly IMultiLingualTranslationRepository _repository;

        public MultiLingualTranslationCrudAppService(IMultiLingualTranslationRepository repository) : base(repository)
        {
            this._repository = repository;
        }
    }
}
