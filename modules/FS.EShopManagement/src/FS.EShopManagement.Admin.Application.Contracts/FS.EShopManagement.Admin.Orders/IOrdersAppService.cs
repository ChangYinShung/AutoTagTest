using EasyAbp.EShop.Orders.Orders.Dtos;
using FS.EShopManagement.Admin.Orders.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FS.EShopManagement.Admin.Orders
{
    public interface IOrdersAppService
            : Volo.Abp.Application.Services.IReadOnlyAppService<
                FS.EShopManagement.Admin.Orders.Dtos.OrderDto,
                Guid,
                GetOrder>
    {
        Task OrderCompleteAndSetReceiptAsync(OrderCompleteAndSetReceipt input);
    }
}
