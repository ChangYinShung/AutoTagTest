using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FS.EShopManagement.Admin.Products
{
    public interface IProductsAppService : Volo.Abp.DependencyInjection.ITransientDependency
    {
        Task PatchProductSkuAsync(Guid productId, Dtos.PatchProductSkuDto input = null);
    }
}
