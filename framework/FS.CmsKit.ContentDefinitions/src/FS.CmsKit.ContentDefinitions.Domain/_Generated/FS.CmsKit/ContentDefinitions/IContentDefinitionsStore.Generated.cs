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
using Volo.Abp.Domain.Services;

namespace FS.CmsKit.ContentDefinitions
{
    public partial interface IContentDefinitionsStore : IDomainService //auto-generated
    {
        IContentTypeDefinitionRepository ContentTypeDefinition { get; }
        IContentTypePartDefinitionRepository ContentTypePartDefinition { get; }
        IContentPartDefinitionRepository ContentPartDefinition { get; }
        IContentPartFieldDefinitionRepository ContentPartFieldDefinition { get; }
        IContentDefinitionRepository ContentDefinition { get; }
    }
}