using AutoMapper;
using EasyAbp.EShop.Orders.Orders;
using FS.EShopManagement.Public.Orders.Dtos;

namespace FS.EShopManagement.Public;

public class EShopManagementPublicApplicationAutoMapperProfile : Profile
{
    public EShopManagementPublicApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<OrderExtraFee, OrderExtraFeeDto>();

        CreateMap<Order, OrderDto>();
    }
}
