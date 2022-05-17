using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FS.EShopManagement.Public.Orders
{
    public interface IOrdersAppService
        : Volo.Abp.Application.Services.IReadOnlyAppService<
                Dtos.OrderDto,
                Guid,
                Dtos.GetOrder>
    {
        Task<EasyAbp.PaymentService.Payments.Dtos.PaymentDto> CreateOrderToPayAsync(Dtos.CreateOrderToPayDto input);
    }
}
