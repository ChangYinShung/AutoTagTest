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
    public class ProductViewRepository : EasyAbpProducts.Products.ProductViewRepository, IProductViewRepository
    {
        public ProductViewRepository(IDbContextProvider<EasyAbpProducts.EntityFrameworkCore.IProductsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public virtual async Task<IQueryable<ProductView>> GetQueryableAsync(IEnumerable<Guid> categoryIds)
        {
            return await JoinProductCategoriesAsync(categoryIds);
        }

        protected virtual async Task<IQueryable<ProductView>> JoinProductCategoriesAsync(IEnumerable<Guid> categoryIds)
        {
            var dbContext = await GetDbContextAsync();

            return from productCategories in dbContext.ProductCategories
                join productViews in dbContext.ProductViews on productCategories.ProductId equals productViews.Id
                where categoryIds.Contains( productCategories.CategoryId)
                select productViews;
        }
    }
}
