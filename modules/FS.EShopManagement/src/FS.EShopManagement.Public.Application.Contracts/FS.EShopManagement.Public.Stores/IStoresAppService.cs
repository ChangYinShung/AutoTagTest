using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FS.EShopManagement.Public.Stores
{
    public interface IStoresAppService : Volo.Abp.DependencyInjection.ITransientDependency
    {
        Task<EasyAbp.EShop.Stores.Stores.Dtos.StoreDto> GetDefaultAsync();
    }
}
