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

namespace FS.CmsKitManagement.ContentRecords.Dtos
{
    public partial class ContentPartRecordAutoMapperProfile : Profile
    {
        public ContentPartRecordAutoMapperProfile()
        {
            CreateMap<FS.CmsKitManagement.ContentRecords.ContentPartRecord, ContentPartRecordDto>()
            .ReverseMap();
        
            CreateMap<ContentPartRecordCreateDto, FS.CmsKitManagement.ContentRecords.ContentPartRecord>();
        
            CreateMap<ContentPartRecordUpdateDto, FS.CmsKitManagement.ContentRecords.ContentPartRecord>();
        
            CreateMap<FS.CmsKitManagement.ContentRecords.ContentPartRecord, ContentPartRecordWithDetailsDto>();
        
            CustomizeConfiguration();
        }
        partial void CustomizeConfiguration();
    }

}