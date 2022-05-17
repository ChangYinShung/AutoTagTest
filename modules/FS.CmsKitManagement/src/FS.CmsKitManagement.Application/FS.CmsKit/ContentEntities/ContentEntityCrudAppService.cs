using FS.CmsKit.ContentEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace FS.CmsKit.ContentEntities
{
    public partial class ContentEntityCrudAppService
    {
        protected override async Task<IQueryable<ContentEntity>> CreateFilteredQueryAsync(ContentEntityGetListDto input)
        {
            var filter = new FS.Entity.EntityFeatures.EntityFeaturesAutoFilter(input.EntityType);

            return filter.ApplyFilterTo((await this._repository.GetQueryableAsync()));
        }
    }
}
