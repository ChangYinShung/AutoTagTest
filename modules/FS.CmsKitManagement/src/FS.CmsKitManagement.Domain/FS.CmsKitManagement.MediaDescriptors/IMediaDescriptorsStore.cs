using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.CmsKit.MediaDescriptors;

namespace FS.CmsKitManagement.MediaDescriptors
{
    public interface IMediaDescriptorsStore : Volo.Abp.DependencyInjection.ITransientDependency
    {
        Task<List<MediaDescriptor>> GetListByPrefixAsync(string prefix, string entityType);
    }
}