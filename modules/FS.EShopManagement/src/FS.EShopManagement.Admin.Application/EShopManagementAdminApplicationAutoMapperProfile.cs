using AutoMapper;
using EasyAbp.EShop.Orders.Orders;
using EasyAbp.EShop.Products.Products.Dtos;
using FS.EShopManagement.Admin.Orders.Dtos;
using FS.EShopManagement.Admin.Products.Dtos;

namespace FS.EShopManagement.Admin;

public class EShopManagementAdminApplicationAutoMapperProfile : Profile
{
    public EShopManagementAdminApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<PatchProductSkuDto, CreateProductSkuDto>();

        CreateMap<OrderExtraFee, OrderExtraFeeDto>();

        CreateMap<Order, OrderDto>();
    }
}
