using EasyAbpProducts=EasyAbp.EShop.Products.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace FS.EShopManagement.Products
{
    public interface IProductViewRepository : EasyAbpProducts.IProductViewRepository
    {
        Task<IQueryable<EasyAbpProducts.ProductView>> GetQueryableAsync(IEnumerable<Guid> categoryIds);
    }
}
