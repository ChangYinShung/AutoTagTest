//------------------------------------------------------------------------------
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
    public partial class ContentDefinitionAutoMapperProfile : Profile
    {
        public ContentDefinitionAutoMapperProfile()
        {
            CreateMap<FS.CmsKit.ContentDefinitions.ContentDefinition, ContentDefinitionDto>()
            .ReverseMap();
        
            CreateMap<ContentDefinitionCreateDto, FS.CmsKit.ContentDefinitions.ContentDefinition>();
        
            CreateMap<ContentDefinitionUpdateDto, FS.CmsKit.ContentDefinitions.ContentDefinition>();
        
            CreateMap<FS.CmsKit.ContentDefinitions.ContentDefinition, ContentDefinitionWithDetailsDto>();
        
            CustomizeConfiguration();
        }
        partial void CustomizeConfiguration();
    }

}
