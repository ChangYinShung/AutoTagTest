using EasyAbp.EShop.Products.Categories;
using EasyAbp.EShop.Products.ProductDetails;
using EasyAbp.EShop.Products.ProductInventories;
using EasyAbp.EShop.Products.Products;
using EasyAbp.EShop.Stores.Stores;
using FS.Abp.Npoi.Mapper;
using FS.EShopManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Uow;
using Volo.Abp.VirtualFileSystem;
using Volo.CmsKit.Admin.MediaDescriptors;

namespace CFTA.Data.EShop
{
    public class EShopDataSeeder : DomainService
    {
        private const string EntityTypeBlogPost = "BlogPost";
        private const int DefaultInventoryCount = 30;

        private VirtualFileNpoiReader virtualFileNpoiReader => this.LazyServiceProvider.LazyGetRequiredService<VirtualFileNpoiReader>();
        private IVirtualFileProvider virtualFileProvider => this.LazyServiceProvider.LazyGetRequiredService<IVirtualFileProvider>();

        private DataService dataService => this.LazyServiceProvider.LazyGetRequiredService<DataService>();

        private IStoreAppService StoreAppService => this.LazyServiceProvider.LazyGetRequiredService<IStoreAppService>();
        private IProductAppService ProductAppService => this.LazyServiceProvider.LazyGetRequiredService<IProductAppService>();
        private IProductInventoryAppService ProductInventoryAppService => this.LazyServiceProvider.LazyGetRequiredService<IProductInventoryAppService>();
        private IProductDetailAppService ProductDetailAppService => this.LazyServiceProvider.LazyGetRequiredService<IProductDetailAppService>();
        private ICategoryAppService CategoryAppService => this.LazyServiceProvider.LazyGetRequiredService<ICategoryAppService>();

        private IStoreRepository StoreRepository => this.LazyServiceProvider.LazyGetRequiredService<IStoreRepository>();


        public async Task CreateStoresAndProductsAsync()
        {
            // My store 為 EasyAbp 的 Seed 建立之資料
            var hasDatas = await this.StoreRepository.GetCountAsync() > 1;
            if (hasDatas) return;

            var mediaDescriptors = await createImageFilesAsync();
            var categories = await createCategories();
            await createStores(categories, mediaDescriptors);

            // 新增 MediaDescriptors
            async Task<List<MediaDescriptorDto>> createImageFilesAsync()
            {
                var filesPath = $"Files/EShop/MediaResources";
                var files = this.virtualFileProvider.GetDirectoryContents(filesPath).ToList();

                var mediaDescriptors = await this.dataService.CreateMediaDesciptorsAsync(EntityTypeBlogPost, files);

                return mediaDescriptors;
            }

            // 新增 Categories
            async Task<List<EasyAbp.EShop.Products.Categories.Dtos.CategoryDto>> createCategories()
            {
                var categories = this.virtualFileNpoiReader.ReadToTreeNode<Files.EShop.Category>();

                var result = new List<EasyAbp.EShop.Products.Categories.Dtos.CategoryDto>();
                await categories.ForEachAsync(async (category) =>
                {
                    result = await this.CreateCategoriesAsync(null, category, result);
                });

                return result;
            }

            // 新增 Store, Product, ProductDetail, ProductAttribute, ProductSku
            async Task createStores(
                List<EasyAbp.EShop.Products.Categories.Dtos.CategoryDto> categories, 
                List<MediaDescriptorDto> mediaDescriptors)
            {
                var stores = this.virtualFileNpoiReader.Read<Files.EShop.Store>();
                stores = stores.Where(x => x.Name != null).ToList();

                var products = this.virtualFileNpoiReader.Read<Files.EShop.Product>();
                var productAttributes = this.virtualFileNpoiReader.Read<Files.EShop.ProductAttribute>();
                var productAttributeOptions = this.virtualFileNpoiReader.Read<Files.EShop.ProductAttributeOption>();

                await stores.ForEachAsync(async (data) =>
                {
                    var store = await this.StoreAppService.CreateAsync(
                        new EasyAbp.EShop.Stores.Stores.Dtos.CreateUpdateStoreDto()
                        {
                            Name = data.Name
                        });

                    var storeProducts = products.Where(x => x.StoreUniqueName == data.UniqueName).ToList();
                    await this.CreateProductsAsync(
                        categories, 
                        store, 
                        storeProducts, 
                        productAttributes, 
                        productAttributeOptions,
                        mediaDescriptors);
                });
            }
        }

        /// <summary>
        /// 遞迴新增 Categories
        /// </summary>
        /// <returns>
        /// 返回的陣列為樹狀打平的陣列
        /// </returns>
        private async Task<List<EasyAbp.EShop.Products.Categories.Dtos.CategoryDto>> CreateCategoriesAsync(Guid? parentId,
            Files.EShop.Category category,
            List<EasyAbp.EShop.Products.Categories.Dtos.CategoryDto> categories)
        {
            var dto = await this.CategoryAppService.CreateAsync(new EasyAbp.EShop.Products.Categories.Dtos.CreateUpdateCategoryDto()
            {
                ParentId = parentId,
                UniqueName = category.UniqueName,
                DisplayName = category.Name,
                Description = "",
                IsHidden = false,
                MediaResources = ""
            });

            categories.Add(dto);

            await category.Children.ForEachAsync(async (child) =>
            {
                var childCategories = await this.CreateCategoriesAsync(dto.Id, child, categories);
            });

            return categories;
        }

        /// <summary>
        /// 新增產品 Product, ProductDetail, ProductAttribute, ProductSku, ProductInventory
        /// </summary>
        private async Task CreateProductsAsync(
            List<EasyAbp.EShop.Products.Categories.Dtos.CategoryDto> categories,
            EasyAbp.EShop.Stores.Stores.Dtos.StoreDto store,
            List<Files.EShop.Product> products,
            List<Files.EShop.ProductAttribute> productAttributes,
            List<Files.EShop.ProductAttributeOption> productAttributeOptions,
            List<MediaDescriptorDto> mediaDescriptors)
        {
            var displayOrder = 0;
            await products.ForEachAsync(async (productItem) =>
            {
                displayOrder++;

                // 過滤目前產品使用的 Attribute, AttributeOptions
                var attributes = productAttributes.Where(x => x.ProductUniqueName == productItem.UniqueName).ToList();
                var attributeOptions = productAttributeOptions
                    .Where(x => attributes.Select(y => y.No).Contains(x.ProductAttributeNo))
                    .ToList();

                // Create ProductDetail
                var productDetail = await this.ProductDetailAppService.CreateAsync(
                    new EasyAbp.EShop.Products.ProductDetails.Dtos.CreateUpdateProductDetailDto()
                    {
                        StoreId = store.Id,
                        Description = productItem.Description
                    });

                var mediaResources = mediaDescriptors.SingleOrDefault(x => x.Name == productItem.MediaResourcesName);

                // Create Product, ProductAttribute, ProductAttributeOptions
                var product = await this.ProductAppService.CreateAsync(
                    new EasyAbp.EShop.Products.Products.Dtos.CreateUpdateProductDto()
                    {
                        StoreId = store.Id,
                        ProductGroupName = "Default",
                        ProductDetailId = productDetail.Id,
                        CategoryIds = getCategoryIds(categories, productItem.CategoryUniqueName),
                        UniqueName = productItem.UniqueName,
                        DisplayName = productItem.Name,
                        ProductAttributes = generateProductAttributes(attributes, attributeOptions),
                        InventoryStrategy = InventoryStrategy.NoNeed,
                        DisplayOrder = displayOrder,
                        MediaResources = mediaResources?.Id.ToString() ?? "",
                        IsPublished = true,
                        IsHidden = false,
                        PaymentExpireIn = null
                    });

                // Create ProductSku
                await createProductSkusAsync(product, productItem.DefaultPrice);
            });



            // 由 Category 取得目前 Product 的 Category Id 陣列
            List<Guid> getCategoryIds(
                List<EasyAbp.EShop.Products.Categories.Dtos.CategoryDto> categories,
                string categoryNos)
            {
                var categoryNoList = categoryNos.Split(",").Select(x => x.Trim().ToLower()).ToList();

                var result = new List<Guid>();
                categoryNoList.ForEach(no =>
                {
                    var category = categories.SingleOrDefault(x => x.UniqueName == no);
                    if (category == null) return;

                    result.Add(category.Id);
                });

                return result;
            }

            // 建立 Attribute, AttributeOptions
            List<EasyAbp.EShop.Products.Products.Dtos.CreateUpdateProductAttributeDto>
                generateProductAttributes(
                    List<Files.EShop.ProductAttribute> attributes,
                    List<Files.EShop.ProductAttributeOption> attributeOptions)
            {
                var result = attributes.Select((attr, attrIndex) =>
                    {
                        var options = attributeOptions
                            .Where(x => x.ProductAttributeNo == attr.No)
                            .Select((option, optionIndex) =>
                            {
                                return new EasyAbp.EShop.Products.Products.Dtos.CreateUpdateProductAttributeOptionDto()
                                {
                                    DisplayName = option.DisplayName,
                                    Description = option.Description,
                                    DisplayOrder = optionIndex
                                };
                            })
                            .ToList();

                        var item = new EasyAbp.EShop.Products.Products.Dtos.CreateUpdateProductAttributeDto()
                        {
                            DisplayName = attr.DisplayName,
                            Description = attr.Description,
                            DisplayOrder = attrIndex,
                            ProductAttributeOptions = options
                        };
                        return item;
                    }).ToList();

                return result;
            }

            // 建立 Sku, Inventory
            async Task createProductSkusAsync(
                EasyAbp.EShop.Products.Products.Dtos.ProductDto product,
                int defaultPrice)
            {
                // 將二維陣列的 Attribute 做全組合，並回傳一維陣列結果
                var skus = product.ProductAttributes
                    .Select(x => x.ProductAttributeOptions.Select(y => new
                    {
                        DisplayName = new List<string> { $"{x.DisplayName} : {y.DisplayName}" },
                        OptionIds = new List<Guid>() { y.Id }
                    }))
                    .Aggregate((a, b) =>
                    {
                        return a.Join(b, (x) => true, (y) => true, (x, y) =>
                        {
                            return new
                            {
                                DisplayName = x.DisplayName.Concat(y.DisplayName).ToList(),
                                OptionIds = x.OptionIds.Concat(y.OptionIds).ToList()
                            };
                        })
                        .ToList();
                    })
                    .ToList();

                await skus.ForEachAsync(async (sku) =>
                {
                    var item = new EasyAbp.EShop.Products.Products.Dtos.CreateProductSkuDto()
                    {
                        ProductDetailId = product.ProductDetailId,
                        AttributeOptionIds = sku.OptionIds,
                        Currency = "NTD",
                        MediaResources = "",
                        Name = $"{product.DisplayName} {String.Join(" , ", sku.DisplayName)}",
                        OrderMinQuantity = 1,
                        OrderMaxQuantity = 999,
                        Price = defaultPrice,
                        OriginalPrice = defaultPrice,
                        PaymentExpireIn = new TimeSpan(0, 10, 0)
                    };
                    product = await this.ProductAppService.CreateSkuAsync(product.Id, item);
                });


                await setDefaultProductInventoryAsync(product);
            }

            // 設定 Sku 預設庫存
            async Task setDefaultProductInventoryAsync(EasyAbp.EShop.Products.Products.Dtos.ProductDto product)
            {
                await product.ProductSkus.ForEachAsync(async (sku) =>
                {
                    await this.ProductInventoryAppService.UpdateAsync(new EasyAbp.EShop.Products.ProductInventories.Dtos.UpdateProductInventoryDto()
                    {
                        ProductId = product.Id,
                        ProductSkuId = sku.Id,
                        ChangedInventory = DefaultInventoryCount
                    });
                });
            }
        }

    }
}
