﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by YinChang.
// 4.4.4
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

namespace FS.Social.Codes
{
    public partial class CodeCrudAppService :  // auto-generated
        Volo.Abp.Application.Services.CrudAppService<
            FS.Social.Codes.Code, 
            FS.Social.Codes.Dtos.CodeWithDetailsDto, 
            FS.Social.Codes.Dtos.CodeDto, 
            Guid, 
            FS.Social.Codes.Dtos.CodeGetListDto, 
            FS.Social.Codes.Dtos.CodeCreateDto, 
            FS.Social.Codes.Dtos.CodeUpdateDto>,
        ICodeCrudAppService
    {
        private readonly ICodeRepository _repository;

        public CodeCrudAppService(ICodeRepository repository) : base(repository)
        {
            this._repository = repository;
        }
    }
}