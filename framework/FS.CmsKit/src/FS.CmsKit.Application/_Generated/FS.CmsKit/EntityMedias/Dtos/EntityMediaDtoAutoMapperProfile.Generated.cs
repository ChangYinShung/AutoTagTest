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

namespace FS.CmsKit.EntityMedias.Dtos
{
    public partial class EntityMediaAutoMapperProfile : Profile
    {
        public EntityMediaAutoMapperProfile()
        {
            CreateMap<FS.CmsKit.EntityMedias.EntityMedia, EntityMediaDto>()
            .ReverseMap();
        
            CreateMap<EntityMediaCreateDto, FS.CmsKit.EntityMedias.EntityMedia>();
        
            CreateMap<EntityMediaUpdateDto, FS.CmsKit.EntityMedias.EntityMedia>();
        
            CreateMap<FS.CmsKit.EntityMedias.EntityMedia, EntityMediaWithDetailsDto>();
        
            CustomizeConfiguration();
        }
        partial void CustomizeConfiguration();
    }

}
