using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Guids;
using Volo.Abp.Uow;

namespace FS.Entity.EntityFeatures
{
    public class EntityFeatureOwnerCreatedOrDeletedDistributedEventHandler<T> :
        IDistributedEventHandler<EntityCreatedEventData<T>>,
        IDistributedEventHandler<EntityDeletedEventData<T>>
        where T : Volo.Abp.Domain.Entities.IEntity<Guid>
    {
        private readonly EntityFeaturesStore entityFeaturesStore;

        protected EntityFeaturesOptions Options { get; }
        protected IGuidGenerator GuidGenerator { get; }
        protected IServiceProvider ServiceProvider { get; }

        public EntityFeatureOwnerCreatedOrDeletedDistributedEventHandler(
            IOptions<EntityFeaturesOptions> options,
            Volo.Abp.Guids.IGuidGenerator guidGenerator,
            IServiceProvider serviceProvider,
            FS.Entity.EntityFeatures.EntityFeaturesStore entityFeaturesStore
            )
        {
            Options=options.Value;
            GuidGenerator=guidGenerator;
            ServiceProvider=serviceProvider;
            this.entityFeaturesStore=entityFeaturesStore;
        }
        [UnitOfWork]
        public virtual async Task HandleEventAsync(EntityDeletedEventData<T> eventData)
        {
            var targets = Options.OwnerFeaturePairs.Where(x => x.Owner.EntityType==eventData.Entity.GetType()).ToList();

            foreach (var e in targets)
            {
                var entityId = eventData.Entity.Id;

                var entityType = e.Owner.EntityTypeFullName;

                var idProperty = e.Feature.GetProperty("EntityId", BindingFlags.Public | BindingFlags.Instance);

                if (idProperty==null)
                    return;

                var featureEntity = await entityFeaturesStore.FindFeatureAsync(e.Feature, entityType, entityId);

                await entityFeaturesStore.DeleteAsync(featureEntity);
            }
        }

        [UnitOfWork]
        public virtual async Task HandleEventAsync(EntityCreatedEventData<T> eventData)
        {
            var targets = Options.OwnerFeaturePairs.Where(x => x.Owner.EntityType==eventData.Entity.GetType()).ToList();

            foreach (var e in targets)
            {
                var idProperty = e.Feature.GetProperty("EntityId", BindingFlags.Public | BindingFlags.Instance);

                if (idProperty==null)
                    return;

                //todo: add entity activator to custom factory method
                var entity = Activator.CreateInstance(e.Feature) as IEntity<Guid>;

                setPropertyValue(entity, "EntityId", eventData.Entity.Id.ToString());

                setPropertyValue(entity, "EntityType", e.Owner.EntityTypeFullName);

                EntityHelper.TrySetId(entity, GuidGenerator.Create);

                await entityFeaturesStore.InsertAsync(entity);
            }

            void setPropertyValue(object target, string propertyName, object setValue)
            {
                var propertyInfo = target.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);

                propertyInfo.SetValue(target, setValue);
            }
        }
    }
}
