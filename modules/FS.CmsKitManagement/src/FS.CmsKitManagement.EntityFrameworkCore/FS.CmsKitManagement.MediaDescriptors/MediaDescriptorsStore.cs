using FS.CmsKitManagement.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.CmsKit.EntityFrameworkCore;
using Volo.CmsKit.MediaDescriptors;

namespace FS.CmsKitManagement.MediaDescriptors
{
    public class MediaDescriptorsStore : IMediaDescriptorsStore
    {
        private readonly ICmsKitDbContext cmsKitDbContext;

        public MediaDescriptorsStore(
            ICmsKitDbContext cmsKitDbContext
            )
        {
            this.cmsKitDbContext = cmsKitDbContext;
        }


        public async Task<List<MediaDescriptor>> GetListByPrefixAsync(string prefix, string entityType)
        {
            var filter = new AutoFilter.MediaDescriptorFilter()
            {
                Prefix = prefix,
                EntityType = entityType
            };

            var result = await filter
                .ApplyFilterTo(this.cmsKitDbContext.MediaDescriptors)
                .ToListAsync();

            return result;
        }
    }
}
