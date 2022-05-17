using System.Reflection;
using AutoMapper;
using Volo.Abp.AutoMapper;

namespace FS.CmsKit.ContentComposites.Dtos
{
    namespace V1
    {
        public partial class ContentItemAutoMapperProfile : Profile
        {
            public ContentItemAutoMapperProfile()
            {
                CreateMap<V1.ContentItemPatchDto, FS.CmsKit.ContentComposites.ContentItem>();

                CustomizeConfiguration();
            }
            partial void CustomizeConfiguration();
        }
    }


}
