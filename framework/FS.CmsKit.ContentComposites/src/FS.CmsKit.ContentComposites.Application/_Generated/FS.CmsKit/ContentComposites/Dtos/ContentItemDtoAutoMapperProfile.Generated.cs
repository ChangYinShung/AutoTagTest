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

namespace FS.CmsKit.ContentComposites.Dtos
{
    public partial class ContentItemAutoMapperProfile : Profile
    {
        public ContentItemAutoMapperProfile()
        {
            CreateMap<FS.CmsKit.ContentComposites.ContentItem, ContentItemDto>()
            .IncludeBase<FS.CmsKit.ContentComposites.ContentComponent, FS.CmsKit.ContentComposites.Dtos.ContentComponentDto>()
            .ReverseMap();
        
            CreateMap<ContentItemCreateDto, FS.CmsKit.ContentComposites.ContentItem>()
            .IncludeBase<FS.CmsKit.ContentComposites.Dtos.ContentComponentCreateDto, FS.CmsKit.ContentComposites.ContentComponent>();
        
            CreateMap<ContentItemUpdateDto, FS.CmsKit.ContentComposites.ContentItem>()
            .IncludeBase<FS.CmsKit.ContentComposites.Dtos.ContentComponentUpdateDto, FS.CmsKit.ContentComposites.ContentComponent>();
        
            CreateMap<FS.CmsKit.ContentComposites.ContentItem, ContentItemWithDetailsDto>()
            .IncludeBase<FS.CmsKit.ContentComposites.ContentComponent, FS.CmsKit.ContentComposites.Dtos.ContentComponentWithDetailsDto>();
        
            CustomizeConfiguration();
        }
        partial void CustomizeConfiguration();
    }

}