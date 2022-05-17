using FS.Entity.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace FS.Entity.EntityFeatures;

public class EntityFeaturesAppService : ApplicationService
{
    private readonly EntityFeaturesOptions Options;
    private readonly EntityFeaturesManager entityFeaturesStore;

    public EntityFeaturesAppService(
            IOptions<FS.Entity.EntityFeatures.EntityFeaturesOptions> entityFeaturesOptions,
            FS.Entity.EntityFeatures.EntityFeaturesManager entityFeaturesStore
        )
    {
        LocalizationResource = typeof(EntityResource);
        ObjectMapperContext = typeof(EntityFeaturesApplicationModule);
        this.Options=entityFeaturesOptions.Value;
        this.entityFeaturesStore=entityFeaturesStore;
    }

    public List<EntityFeature> GetListEntityFeaturesAsync()
    {
        var entityTypes = Options.ToList();
        return entityTypes.Select(et =>
        {
            return new EntityFeature()
            {
                Name = et.Key.Name,
                Definitions = et.Value.Select(e =>
                {
                    return e.Value;
                }).ToList()
            };
        }).ToList();
    }
    //todo: replace entity with dto,need to add mapType into options?
    public async Task<Dictionary<string, object>> GetListFeaturesAsync(string entityType, string entityId)
    {
        var ownerEntity = await entityFeaturesStore.FindAsync(entityType, entityId);

        var allEntityFeatures = await this.entityFeaturesStore.GetFeatureEntityAsync(ownerEntity);

        return allEntityFeatures;

    }
}
