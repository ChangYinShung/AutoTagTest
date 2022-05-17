using System.Reflection;
using AutoMapper;
using Volo.Abp.AutoMapper;

namespace FS.CmsKit.ContentComposites.Dtos
{
    namespace V1
    {
        public partial class ContentCompositeAutoMapperProfile : Profile
        {
            public ContentCompositeAutoMapperProfile()
            {

                CreateMap<V1.ContentCompositePatchDto, FS.CmsKit.ContentComposites.ContentComposite>();

                CustomizeConfiguration();
            }
            partial void CustomizeConfiguration();
        }
    }


}
