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

namespace FS.Entity.MultiLinguals.Dtos
{
    public partial class MultiLingualAutoMapperProfile : Profile
    {
        public MultiLingualAutoMapperProfile()
        {
            CreateMap<FS.Entity.MultiLinguals.MultiLingual, MultiLingualDto>()
            .ReverseMap();
        
            CreateMap<MultiLingualCreateDto, FS.Entity.MultiLinguals.MultiLingual>();
        
            CreateMap<MultiLingualUpdateDto, FS.Entity.MultiLinguals.MultiLingual>();
        
            CreateMap<FS.Entity.MultiLinguals.MultiLingual, MultiLingualWithDetailsDto>();
        
            CustomizeConfiguration();
        }
        partial void CustomizeConfiguration();
    }

}
