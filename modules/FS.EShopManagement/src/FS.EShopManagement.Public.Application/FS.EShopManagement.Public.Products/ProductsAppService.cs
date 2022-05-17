using EasyAbp.EShop.Products.Categories;
using EasyAbp.EShop.Products.Products.Dtos;
using FS.EShopManagement.Public.Products.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Linq.Dynamic.Core;
using EasyAbp.EShop.Products.Products;
using System;

namespace FS.EShopManagement.Public.Products
{

    public class ProductsAppService : ApplicationService, IProductsAppService
    {
        private ICategoryRepository categoryRepository => this.LazyServiceProvider.LazyGetRequiredService<ICategoryRepository>();
        private FS.EShopManagement.Products.IProductRepository productsRepository => this.LazyServiceProvider.LazyGetRequiredService<FS.EShopManagement.Products.IProductRepository>();
        private IProductManager productManager => this.LazyServiceProvider.LazyGetRequiredService<IProductManager>();

        public async Task<List<ProductSkuDto>> PostProductSkusByIdsAsync(List<ProductSkuKeyDto> productSkuKeys)
        {
            var productIds = productSkuKeys.Select(x => x.ProductId).Distinct().ToList();
            var products = await this.AsyncExecuter.ToListAsync((await this.productsRepository.WithDetailsAsync())
                .Where(x => productIds.Contains(x.Id)));

            var result = new List<ProductSkuDto>();
            products.ForEach(product =>
            {
                var productSkuIds = productSkuKeys
                .Where(x => x.ProductId == product.Id)
                .Select(x => x.ProductSkuId)
                .Distinct()
                .ToList();

                var skus = product.ProductSkus.Where(x => productSkuIds.Contains(x.Id)).ToList();
                skus.ForEach(sku =>
                {
                    var skuDto = ObjectMapper.Map<ProductSku, ProductSkuDto>(sku);
                    skuDto.Price = sku.Price;
                    result.Add(skuDto);
                });
            });

            return result;
        }

        public async Task<PagedResultDto<ProductDto>> GetProductWithDetailAsync(GetProductWithDetail input)
        {
            var searchCategoryIdsQuery = await (input.CategoryIds.Count() > 0 ?
                this.productsRepository.GetQueryableAsync(input.CategoryIds) :
                this.productsRepository.WithDetailsAsync());

            var productIdsQuery = searchCategoryIdsQuery.Select(x => x.Id);
            var query = (await this.productsRepository.WithDetailsAsync())
                .Where(x => productIdsQuery.Contains(x.Id))
                .WhereIf(!String.IsNullOrEmpty(input.Filter), x => x.DisplayName.Contains(input.Filter));

            var totalCount = await AsyncExecuter.CountAsync(query);

            query = query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            if (!String.IsNullOrEmpty(input.Sorting))
            {
                query = query
                    .OrderBy(input.Sorting);
            }

            var items = await this.AsyncExecuter.ToListAsync(query);
            var itemDtos = ObjectMapper.Map<List<Product>, List<ProductDto>>(items);
            itemDtos.ForEach(dto =>
            {
                var product = items.Single(y => y.Id == dto.Id);
                var priceModel = LoadDtoPriceDataAsync(product, dto);
            });

            return new PagedResultDto<ProductDto>()
            {
                Items = itemDtos,
                TotalCount = totalCount,
            };
        }

        protected virtual async Task<ProductDto> LoadDtoPriceDataAsync(Product product, ProductDto productDto)
        {
            foreach (var productSku in product.ProductSkus)
            {
                var productSkuDto = productDto.ProductSkus.First(x => x.Id == productSku.Id);

                var priceDataModel = await productManager.GetRealPriceAsync(product, productSku);

                productSkuDto.Price = priceDataModel.Price;
                productSkuDto.DiscountedPrice = priceDataModel.DiscountedPrice;
            }

            if (productDto.ProductSkus.Count > 0)
            {
                productDto.MinimumPrice = productDto.ProductSkus.Min(sku => sku.Price);
                productDto.MaximumPrice = productDto.ProductSkus.Max(sku => sku.Price);
            }

            return productDto;
        }

        public async Task<List<TestProductSkusDto>> GetTestProductSkusAsync()
        {
            var categories = await this.categoryRepository.GetListAsync();

            var data = new List<TestProductSkusDto>();
            
            foreach (var category in categories)
            {
                var query = await productsRepository.GetQueryableAsync(new[] { category.Id });

                var product = (await productsRepository.WithDetailsAsync())
                    .First(x => query.Select(y => y.Id).Contains(x.Id));

                var sku = product.ProductSkus.First();
                data.Add(new TestProductSkusDto()
                {
                    StoreId = product.StoreId,
                    ProductId = product.Id,
                    ProductSkuId = sku.Id,
                    ProductName = product.DisplayName,
                    ProductSkuName = sku.Name,
                    Price = (int)sku.Price
                });
            }

            return data;
        }
    }
}
