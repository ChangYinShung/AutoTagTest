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

namespace FS.FormManagement.EntityForms.Dtos
{
    public partial class EntityFormAutoMapperProfile : Profile
    {
        public EntityFormAutoMapperProfile()
        {
            CreateMap<FS.FormManagement.EntityForms.EntityForm, EntityFormDto>()
            .ReverseMap();
        
            CreateMap<EntityFormCreateDto, FS.FormManagement.EntityForms.EntityForm>();
        
            CreateMap<EntityFormUpdateDto, FS.FormManagement.EntityForms.EntityForm>();
        
            CreateMap<FS.FormManagement.EntityForms.EntityForm, EntityFormWithDetailsDto>();
        
            CustomizeConfiguration();
        }
        partial void CustomizeConfiguration();
    }

}