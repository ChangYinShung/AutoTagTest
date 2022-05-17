using FS.EShopManagement.Stores;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using EasyAbp.EShop.Stores.Stores;
using EasyAbp.EShop.Stores.Stores.Dtos;

namespace FS.EShopManagement.Public.Stores
{
    public class StoresAppService : ApplicationService, IStoresAppService
    {
        private readonly StoresOptions storeOptions;
        private readonly IStoreRepository storeRepository;

        public StoresAppService(
            IOptions<StoresOptions> storeOptions,
            IStoreRepository storeRepository)
        {
            this.storeOptions=storeOptions.Value;
            this.storeRepository=storeRepository;
        }

        public async Task<StoreDto> GetDefaultAsync()
        {
            var store = await this.AsyncExecuter.FirstOrDefaultAsync(
                (await this.storeRepository.WithDetailsAsync())
                .Where(x => x.Name == storeOptions.DefaultStoreName));

            return ObjectMapper.Map<Store, StoreDto>(store);
        }
    }
}
