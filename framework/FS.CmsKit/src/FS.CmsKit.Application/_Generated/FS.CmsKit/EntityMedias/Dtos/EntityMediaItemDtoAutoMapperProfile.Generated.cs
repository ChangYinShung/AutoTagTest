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

namespace FS.CmsKit.EntityMedias.Dtos
{
    public partial class EntityMediaItemAutoMapperProfile : Profile
    {
        public EntityMediaItemAutoMapperProfile()
        {
            CreateMap<FS.CmsKit.EntityMedias.EntityMediaItem, EntityMediaItemDto>()
            .ReverseMap();
        
            CreateMap<EntityMediaItemCreateDto, FS.CmsKit.EntityMedias.EntityMediaItem>();
        
            CreateMap<EntityMediaItemUpdateDto, FS.CmsKit.EntityMedias.EntityMediaItem>();
        
            CreateMap<FS.CmsKit.EntityMedias.EntityMediaItem, EntityMediaItemWithDetailsDto>();
        
            CustomizeConfiguration();
        }
        partial void CustomizeConfiguration();
    }

}