using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.CmsKit.MediaDescriptors;

namespace FS.CmsKitManagement.Attachments
{
    public partial interface IAttachmentsStore
    {
        Task<List<MediaDescriptor>> GetMediaDescriptorsAsync(List<Guid> mediaDescriptorIds);

        Task<Attachment> CreateAttachmentMediaAsync<T>(T entity, MediaDescriptor mediaDescriptor)
            where T : Volo.Abp.Domain.Entities.IEntity<Guid>;

    }
}
