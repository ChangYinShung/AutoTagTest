using FS.Entity.EntityFeatures;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.CmsKit.MediaDescriptors;

namespace FS.CmsKitManagement.Attachments
{
    public partial class AttachmentsStore : IAttachmentsStore
    {

        public Task<Attachment> CreateAttachmentMediaAsync<T>(T entity, MediaDescriptor mediaDescriptor) where T : IEntity<Guid>
        {
            throw new NotImplementedException();
        }

        public Task<List<MediaDescriptor>> GetMediaDescriptorsAsync(List<Guid> mediaDescriptorIds)
        {
            throw new NotImplementedException();
        }
        //protected IOptions<EntityFeaturesOptions> Options => this.LazyServiceProvider.LazyGetRequiredService<IOptions<EntityFeaturesOptions>>();
        //private IMediaDescriptorRepository MediaDescriptorRepository => this.LazyServiceProvider.LazyGetRequiredService<IMediaDescriptorRepository>();

        //public async Task<List<MediaDescriptor>> GetMediaDescriptorsAsync(List<Guid> mediaDescriptorIds)
        //{
        //    var result = new List<MediaDescriptor>();
        //    foreach (var id in mediaDescriptorIds)
        //    {
        //        var item = await this.MediaDescriptorRepository.GetAsync(id);
        //        result.Add(item);
        //    }

        //    return result;
        //}

        //public async Task<AttachmentMedia> CreateAttachmentMediaAsync<T>(T entity, MediaDescriptor mediaDescriptor)
        //    where T : Volo.Abp.Domain.Entities.IEntity<Guid>
        //{
        //    var options = Options.Value;

        //    return new AttachmentMedia(GuidGenerator.Create())
        //    {
        //        MediaDescriptorId = mediaDescriptor.Id,
        //        EntityType = options.GetOrDefault<AttachmentMedia>().GetOrDefault<T>().EntityType,
        //        EntityId = entity.Id.ToString(),
        //        TenantId = CurrentTenant.Id
        //    };
        //}
        //public IAttachmentRepository Attachment => throw new NotImplementedException();

        //public IAttachmentMediaDescriptorRepository AttachmentMediaDescriptor => throw new NotImplementedException();

        //public Task<AttachmentMediaDescriptor> CreateAttachmentMediaAsync<T>(T entity, MediaDescriptor mediaDescriptor) where T : IEntity<Guid>
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<List<MediaDescriptor>> GetMediaDescriptorsAsync(List<Guid> mediaDescriptorIds)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
