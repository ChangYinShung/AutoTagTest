using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.Application.Dtos;
using EasyAbp.EShop.Orders;
using FS.EShopManagement.Public.Orders;
using Volo.Abp.Users;
using System;
using System.Threading.Tasks;
using System.Linq;
using Volo.Abp.Data;

namespace CFTA.Web.Public.Pages.EShop.Orders
{

    public class OrderModel : PageModel
    {
        private readonly FS.EShopManagement.Public.Orders.IOrdersAppService _fsOrdersAppService;
        private readonly ICurrentUser _currentUser;

        public FS.EShopManagement.Public.Orders.Dtos.OrderDto OrderDto { get; set; }
        public decimal TotalProductExtraFee { get; set; } = 0;

        public OrderModel(
            IOrdersAppService fsOrdersAppService,
            
            ICurrentUser currentUser)
        {
            _fsOrdersAppService = fsOrdersAppService;
            
            _currentUser = currentUser;

        }

        public async Task OnGet(Guid OrderId)
        {
            //TODO : OrderId not found should Redirect to Order List page
            OrderDto = await _fsOrdersAppService.GetAsync(OrderId);
            OrderDto.OrderExtraFees = OrderDto.OrderExtraFees
                .Where(x => x.Key == "ShoppingFee")
                .ToList();

            decimal totalProductExtraFee = 0;
            OrderDto.OrderLines.ForEach(x =>
            {
                decimal fee = x.GetProperty<decimal>("TotalExtraFee");
                totalProductExtraFee += fee;
            });

            this.TotalProductExtraFee = totalProductExtraFee;
        }
    }
}
