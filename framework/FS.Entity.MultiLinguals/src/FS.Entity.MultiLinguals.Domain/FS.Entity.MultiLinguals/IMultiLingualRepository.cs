using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace FS.Entity.MultiLinguals
{
    public partial interface IMultiLingualRepository
    {
        Task<MultiLingual> FindByAsync<T>(T ownerEntity)
            where T : IEntity<Guid>;
    }
}
