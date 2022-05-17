using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace FS.Entity.MultiLinguals
{
    public partial interface IMultiLingualsStore : IDomainService
    {

        Task<MultiLingual> CreateMultiLingualAsync(string entityType, string entityId);

        Task<MultiLingualTranslation> CreateMultiLingualTranslationAsync(MultiLingual entity, string culture);


    }
}
