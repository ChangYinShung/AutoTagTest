using System;
using System.Linq;
using System.Collections.Generic;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using System.Threading.Tasks;
using FS.Entity.MultiLinguals.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Volo.Abp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FS.Entity.MultiLinguals.EntityFrameworkCore
{
    public partial class EfCoreMultiLingualRepository
    {
        protected FS.Entity.EntityFeatures.EntityFeaturesOptions entityFeaturesOptions
            => this.LazyServiceProvider.LazyGetRequiredService<IOptions<FS.Entity.EntityFeatures.EntityFeaturesOptions>>().Value;
        public async Task<MultiLingual> FindByAsync<T>(T ownerEntity)
            where T : IEntity<Guid>
        {
            if (!entityFeaturesOptions[typeof(MultiLingual)].ContainsKey(typeof(T)))
            {
                throw new Exception("this type {0} has not MultiLingual Feature , please register first");
            }
            var definition = entityFeaturesOptions[typeof(MultiLingual)][typeof(T)];

            var query = (await this.GetQueryableAsync());

            var filter = new FS.Entity.EntityFeatures.EntityFeaturesAutoFilter(definition.EntityTypeFullName, ownerEntity.Id.ToString());

            var multiLingual = await filter.ApplyFilterTo(query).SingleOrDefaultAsync();

            return multiLingual;
        }
    }
}
