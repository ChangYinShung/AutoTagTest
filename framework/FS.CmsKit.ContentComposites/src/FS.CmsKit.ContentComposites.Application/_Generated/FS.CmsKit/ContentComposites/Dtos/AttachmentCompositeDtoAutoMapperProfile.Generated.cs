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
    public partial class AttachmentCompositeAutoMapperProfile : Profile
    {
        public AttachmentCompositeAutoMapperProfile()
        {
            CreateMap<FS.CmsKit.ContentComposites.AttachmentComposite, AttachmentCompositeDto>()
            .IncludeBase<FS.CmsKit.ContentComposites.ContentComponent, FS.CmsKit.ContentComposites.Dtos.ContentComponentDto>()
            .ReverseMap();
        
            CreateMap<AttachmentCompositeCreateDto, FS.CmsKit.ContentComposites.AttachmentComposite>()
            .IncludeBase<FS.CmsKit.ContentComposites.Dtos.ContentComponentCreateDto, FS.CmsKit.ContentComposites.ContentComponent>();
        
            CreateMap<AttachmentCompositeUpdateDto, FS.CmsKit.ContentComposites.AttachmentComposite>()
            .IncludeBase<FS.CmsKit.ContentComposites.Dtos.ContentComponentUpdateDto, FS.CmsKit.ContentComposites.ContentComponent>();
        
            CreateMap<FS.CmsKit.ContentComposites.AttachmentComposite, AttachmentCompositeWithDetailsDto>()
            .IncludeBase<FS.CmsKit.ContentComposites.ContentComponent, FS.CmsKit.ContentComposites.Dtos.ContentComponentWithDetailsDto>();
        
            CustomizeConfiguration();
        }
        partial void CustomizeConfiguration();
    }

}
