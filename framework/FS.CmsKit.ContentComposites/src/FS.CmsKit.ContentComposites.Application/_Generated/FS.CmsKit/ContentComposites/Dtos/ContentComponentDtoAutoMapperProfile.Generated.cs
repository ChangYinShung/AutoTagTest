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

namespace FS.CmsKit.ContentComposites.Dtos
{
    public partial class ContentComponentAutoMapperProfile : Profile
    {
        public ContentComponentAutoMapperProfile()
        {
            CreateMap<FS.CmsKit.ContentComposites.ContentComponent, ContentComponentDto>()
            .ReverseMap();
        
            CreateMap<ContentComponentCreateDto, FS.CmsKit.ContentComposites.ContentComponent>();
        
            CreateMap<ContentComponentUpdateDto, FS.CmsKit.ContentComposites.ContentComponent>();
        
            CreateMap<FS.CmsKit.ContentComposites.ContentComponent, ContentComponentWithDetailsDto>();
        
            CustomizeConfiguration();
        }
        partial void CustomizeConfiguration();
    }

}
