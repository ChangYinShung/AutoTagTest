using FS.CmsKit.ContentEntities.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Events.Distributed;

namespace FS.CmsKit.ContentComposites.EventBus
{
    public class ContentEntityCreatedHandler :
        Volo.Abp.EventBus.Distributed.IDistributedEventHandler<EntityCreatedEto<ContentEntityEto>>,
        Volo.Abp.DependencyInjection.ITransientDependency
    {
        public ContentEntityCreatedHandler()
        {
            
        }
        public Task HandleEventAsync(EntityCreatedEto<ContentEntityEto> eventData)
        {

            return Task.CompletedTask;
        }
    }
}
