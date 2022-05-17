using EasyAbp.EShop.Orders.Orders;
using Volo.Abp.Domain.Services;

namespace FS.EShopManagement.Orders
{
    public class OrdersStore : DomainService

    {
        private readonly IOrderRepository orderRepository;

        public OrdersStore(
            EasyAbp.EShop.Orders.Orders.IOrderRepository orderRepository
            )
        {
            this.orderRepository=orderRepository;
        }
    }
}
