using System.Reflection;
using AutoMapper;
using Volo.Abp.AutoMapper;

namespace FS.CmsKit.ContentDefinitions.Dtos
{
    public partial class ContentDefinitionAutoMapperProfile : Profile
    {

        partial void CustomizeConfiguration()
        {
            CreateMap<FS.CmsKit.ContentDefinitions.ContentDefinition, V1.ContentDefinitionWithDetailsDto>();
        }
    }

}
