using FS.CmsKitManagement.MediaDescriptors.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.ObjectMapping;
using Volo.CmsKit.Admin.MediaDescriptors;
using Volo.CmsKit.MediaDescriptors;

namespace FS.CmsKitManagement.MediaDescriptors
{
    public class MediaDescriptorsAppService : CmsKitManagementAppService
    {
        private IMediaDescriptorsStore MediaDescriptors => this.LazyServiceProvider.LazyGetRequiredService<IMediaDescriptorsStore>();

        public async Task<List<MediaDescriptorDto>> GetListAsync(MediaDescriptorGetListDto input)
        {
            var datas = await this.MediaDescriptors.GetListByPrefixAsync(input.Prefix, input.EntityType);

            return ObjectMapper.Map<List<MediaDescriptor>, List<MediaDescriptorDto>>(datas);
        }
        
    }
}
