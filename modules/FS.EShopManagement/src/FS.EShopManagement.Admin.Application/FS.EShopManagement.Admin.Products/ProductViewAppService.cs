using EasyAbp.EShop.Products.Products;
using EasyAbp.EShop.Products.Products.CacheItems;
using EasyAbp.EShop.Products.Products.Dtos;
using FS.EShopManagement.Admin.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Caching;

namespace FS.EShopManagement.Admin.Products
{
    public class ProductViewAppService : EasyAbp.EShop.Products.Products.ProductViewAppService, IProductViewAppService
    {
        private readonly FS.EShopManagement.Products.IProductViewRepository _productViewRepository;
        private readonly IDistributedCache<ProductViewCacheItem> _cache;

        public ProductViewAppService(
            IProductViewCacheKeyProvider productViewCacheKeyProvider,
            IDistributedCache<ProductViewCacheItem> cache,
            EasyAbp.EShop.Products.Products.IProductManager productManager,
            EasyAbp.EShop.Products.Products.IProductRepository productRepository,
            FS.EShopManagement.Products.IProductViewRepository repository)
            : base(productViewCacheKeyProvider, cache, productManager, productRepository, repository)
        {
            _productViewRepository = repository;
            _cache = cache;
        }

        public virtual async Task<PagedResultDto<ProductViewDto>> GetListV2Async(GetProductViewListInput input)
        {
            if (await _cache.GetAsync(await GetCacheKeyAsync(input.StoreId), true) == null)
            {
                await BuildStoreProductViewsAsync(input.StoreId);
            }

            var query = (await CreateFilteredQueryAsync(input))
                .WhereIf(!String.IsNullOrEmpty(input.Filter), x => x.DisplayName.ToLower().Contains(input.Filter.ToLower().Trim()))
                .WhereIf(input.ShowUnpublished != true, x => x.IsPublished == true);

            var totalCount = await AsyncExecuter.CountAsync(query);

            query = ApplyPaging(query, input);
            query = ApplySorting(query, input);

            var productViews = await AsyncExecuter.ToListAsync(query);
            var entityDtos = await MapToGetListOutputDtosAsync(productViews);

            return new PagedResultDto<ProductViewDto>(
                totalCount,
                entityDtos
            );
        }

        protected virtual IQueryable<ProductView> ApplySorting(IQueryable<ProductView> query, GetProductViewListInput input)
        {
            return ApplySorting(query, new GetProductListInput
            {
                Sorting = input.Sorting
            });
        }

        protected virtual IQueryable<ProductView> ApplyPaging(IQueryable<ProductView> query, GetProductViewListInput input)
        {
            return ApplySorting(query, new GetProductListInput
            {
                MaxResultCount = input.MaxResultCount,
                SkipCount = input.SkipCount,
            });
        }

        protected async Task<IQueryable<ProductView>> CreateFilteredQueryAsync(GetProductViewListInput input)
        {
            var query = null != input.CategoryIds && input.CategoryIds.Count > 0
                ? (await _productViewRepository.GetQueryableAsync(input.CategoryIds))
                : (await _productViewRepository.WithDetailsAsync());

            return query
                .Where(x => x.StoreId == input.StoreId);
        }
    }
}
