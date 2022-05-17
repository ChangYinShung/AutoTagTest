using EasyAbp.EShop.Products.Products.Dtos;
using FS.EShopManagement.Public.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace FS.EShopManagement.Public.Products
{
    public interface IProductViewAppService : Volo.Abp.DependencyInjection.ITransientDependency
    {
        Task<PagedResultDto<ProductViewDto>> GetListV2Async(GetProductViewListInput input);
    }
}
