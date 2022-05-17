using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace FS.Entity.EntityFeatures
{
    public class EntityFeaturesManager : Volo.Abp.Domain.Services.DomainService
    {
        private readonly EntityFeaturesOptions options;
        private readonly EntityFeaturesStore entityFeaturesStore;

        public EntityFeaturesManager(
            IOptions<EntityFeaturesOptions> options,
            FS.Entity.EntityFeatures.EntityFeaturesStore entityFeaturesStore
            )
        {
            this.options=options.Value;
            this.entityFeaturesStore=entityFeaturesStore;
        }

        public async Task<IEntity<Guid>> FindAsync(string ownerTypeFullName, string entityId)
        {

            var target = this.options.OwnerFeaturePairs.Where(pair => pair.Owner.EntityTypeFullName==ownerTypeFullName).FirstOrDefault();

            var ownerEntity = await entityFeaturesStore.FindOwnerAsync(target.Owner.EntityType, Guid.Parse(entityId));

            return ownerEntity;
        }

        public async Task<Dictionary<string, object>> GetFeatureEntityAsync<T>(T ownerEntity)
            where T : IEntity<Guid>
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            //todo: consider add IEntityFeature for EntityType and EntityId property get
            Guid entityId = ownerEntity.Id;

            var ownerFeatures = this.options.OwnerFeaturePairs
                .Where(x => x.Owner.EntityType==ownerEntity.GetType())
                .ToList();

            await ownerFeatures
                .ForEachAsync(async pair =>
            {
                var entityType = pair.Owner.EntityTypeFullName;

                var featureEntity = await entityFeaturesStore.FindFeatureAsync(pair.Feature, entityType, entityId);

                result[pair.Feature.Name]=featureEntity;
            });

            return result;



        }
    }
}
