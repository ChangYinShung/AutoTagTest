using FS.Entity.EntityFeatures;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FS.Entity.MultiLinguals
{
    public partial class MultiLingualsStore : IMultiLingualsStore
    {
        protected IOptions<EntityFeaturesOptions> Options => LazyServiceProvider.LazyGetRequiredService<IOptions<EntityFeaturesOptions>>();

        //todo: get default culture //DefaultCulture
        public virtual Task<MultiLingual> CreateMultiLingualAsync(string entityType, string entityId)
        {
            var result = new MultiLingual(GuidGenerator.Create())
            {
                EntityType = entityType,
                EntityId = entityId,
                TenantId = CurrentTenant.Id,

            };
            return Task.FromResult(result);
        }

        public virtual Task<MultiLingualTranslation> CreateMultiLingualTranslationAsync(MultiLingual entity, string culture)
        {
            var result = new MultiLingualTranslation(GuidGenerator.Create())
            {
                Culture = culture,
                MultiLingual = entity,
                MultiLingualId = entity.Id,
                TenantId = CurrentTenant.Id
            };
            return Task.FromResult(result);
        }
    }
}
