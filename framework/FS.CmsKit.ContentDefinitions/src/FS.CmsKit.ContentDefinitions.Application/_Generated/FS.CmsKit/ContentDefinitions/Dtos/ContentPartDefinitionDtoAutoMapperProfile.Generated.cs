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
    public partial class ContentPartDefinitionAutoMapperProfile : Profile
    {
        public ContentPartDefinitionAutoMapperProfile()
        {
            CreateMap<FS.CmsKit.ContentDefinitions.ContentPartDefinition, ContentPartDefinitionDto>()
            .ReverseMap();
        
            CreateMap<ContentPartDefinitionCreateDto, FS.CmsKit.ContentDefinitions.ContentPartDefinition>();
        
            CreateMap<ContentPartDefinitionUpdateDto, FS.CmsKit.ContentDefinitions.ContentPartDefinition>();
        
            CreateMap<FS.CmsKit.ContentDefinitions.ContentPartDefinition, ContentPartDefinitionWithDetailsDto>();
        
            CustomizeConfiguration();
        }
        partial void CustomizeConfiguration();
    }

}