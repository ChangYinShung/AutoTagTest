﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by YinChang.
// 5.1.3
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
using System.Reflection;
using AutoMapper;
using Volo.Abp.AutoMapper;

namespace FS.CmsKit.ContentDefinitions.Dtos
{
    public partial class ContentTypeDefinitionAutoMapperProfile : Profile
    {
        public ContentTypeDefinitionAutoMapperProfile()
        {
            CreateMap<FS.CmsKit.ContentDefinitions.ContentTypeDefinition, ContentTypeDefinitionDto>()
            .ReverseMap();
        
            CreateMap<ContentTypeDefinitionCreateDto, FS.CmsKit.ContentDefinitions.ContentTypeDefinition>();
        
            CreateMap<ContentTypeDefinitionUpdateDto, FS.CmsKit.ContentDefinitions.ContentTypeDefinition>();
        
            CreateMap<FS.CmsKit.ContentDefinitions.ContentTypeDefinition, ContentTypeDefinitionWithDetailsDto>();
        
            CustomizeConfiguration();
        }
        partial void CustomizeConfiguration();
    }

}
