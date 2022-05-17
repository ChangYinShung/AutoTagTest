using EasyAbp.EShop.Products.ProductInventories;
using EasyAbp.EShop.Products.ProductInventories.Dtos;
using EasyAbp.EShop.Products.Products;
using EasyAbp.EShop.Products.Products.Dtos;
using FS.EShopManagement.Admin.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Uow;

namespace FS.EShopManagement.Admin.Products
{

    public class ProductsAppService : ApplicationService, IProductsAppService
    {
        private readonly IProductAppService productAppService;
        private readonly IProductInventoryAppService productInventoryAppService;
        private readonly IProductRepository productRepository;

        public ProductsAppService(
            EasyAbp.EShop.Products.Products.IProductAppService productAppService,
            EasyAbp.EShop.Products.ProductInventories.IProductInventoryAppService productInventoryAppService,
            EasyAbp.EShop.Products.Products.IProductRepository productRepository
            )
        {
            this.productAppService = productAppService;
            this.productInventoryAppService = productInventoryAppService;
            this.productRepository = productRepository;
        }

        protected virtual async Task ClearProductSkus(Guid productId)
        {
            var product = await productRepository.FindAsync(productId, true);

            product.ProductSkus.Clear();

            await productRepository.UpdateAsync(product);
        }

        [UnitOfWork(IsDisabled = true)]
        public async Task PatchProductSkuAsync(Guid productId, PatchProductSkuDto input = null)
        {
            await ClearProductSkus(productId);

            var product = await productRepository.FindAsync(productId, true);

            var productOptions = product.ProductAttributes.SelectMany(pa => pa.ProductAttributeOptions).ToDictionary(x => x.Id, y => y);

            var productOptionSet = product.ProductAttributes
                .SelectMany(x =>
                {
                    return x.ProductAttributeOptions.Select(y => new { Attribute = x, Option = y });
                }).ToDictionary(x => x.Option.Id, y => y);

            var attributes = product.ProductAttributes.Select(x => x.ProductAttributeOptions.Select(o => o.Id.ToString())).ToList();

            var inputs = attributes
                .Aggregate((a, b) => a.Join(b, o => true, i => true, (x, y) => $"{x},{y}"))
                .Select(x => x.Split(',').Select(y => Guid.Parse(y)).ToArray())
                .Select(x =>
                {
                    var result = new CreateProductSkuDto();
                    this.ObjectMapper.Map(input, result);
                    result.AttributeOptionIds = x.ToList();
                    result.PaymentExpireIn = new TimeSpan(0, 10, 0);

                    var texts = x
                    .Select(y => productOptionSet[y])
                    .Select(y => $"{y.Attribute.DisplayName} : {y.Option.DisplayName}");

                    result.Name = $"{product.DisplayName} {string.Join(" , ", texts)}";
                    result.PaymentExpireIn = new TimeSpan(0, input.PaymentExpireInMin, 0);
                    return result;
                })
                .ToList();

            foreach (var i in inputs)
            {
                var newProduct = await this.productAppService.CreateSkuAsync(productId, i);

                UpdateProductInventoryDto updateProductInventory = new UpdateProductInventoryDto()
                {
                    ChangedInventory = input.InitialInventory,
                    ProductId = newProduct.Id,
                    ProductSkuId = newProduct.ProductSkus.LastOrDefault().Id
                };

                await this.productInventoryAppService.UpdateAsync(updateProductInventory);

            }

        }
    }
}