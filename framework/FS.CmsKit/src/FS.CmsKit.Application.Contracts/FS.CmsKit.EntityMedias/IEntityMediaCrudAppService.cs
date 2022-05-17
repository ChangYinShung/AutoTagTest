using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace FS.CmsKit.EntityMedias
{
    namespace V1
    {
        public partial interface IEntityMediaCrudAppService : Volo.Abp.DependencyInjection.ITransientDependency
        {
            Task<Dtos.EntityMediaWithDetailsDto> GetFindByEntityTypeAsync(string entityType);
        }
    }
}
