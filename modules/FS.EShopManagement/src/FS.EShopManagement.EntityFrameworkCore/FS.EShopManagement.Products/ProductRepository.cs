using EasyAbpProducts=EasyAbp.EShop.Products;
using EasyAbp.EShop.Products.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace FS.EShopManagement.Products
{
    public class ProductRepository : EasyAbpProducts.Products.ProductRepository, IProductRepository
    {
        public ProductRepository(IDbContextProvider<EasyAbpProducts.EntityFrameworkCore.IProductsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public virtual async Task<IQueryable<Product>> GetQueryableAsync(IEnumerable<Guid> categoryIds)
        {
            return await JoinProductCategoriesAsync(categoryIds);
        }

        protected virtual async Task<IQueryable<Product>> JoinProductCategoriesAsync(IEnumerable<Guid> categoryIds)
        {
            var dbContext = await GetDbContextAsync();

            return from productCategories in dbContext.ProductCategories
                join products in dbContext.Products on productCategories.ProductId equals products.Id
                where categoryIds.Contains( productCategories.CategoryId)
                select products;
        }
    }
}
