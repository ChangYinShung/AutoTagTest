using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.Application.Dtos;
using FS.EShopManagement.Public.Orders;
using Volo.Abp.Users;
using System;
using System.Threading.Tasks;

namespace CFTA.Web.Public.Pages.EShop.Orders
{
    public class IndexModel : PageModel
    {


        private readonly FS.EShopManagement.Public.Orders.IOrdersAppService _fsOrdersAppService;
        private readonly ICurrentUser _currentUser;

        public PagedResultDto<FS.EShopManagement.Public.Orders.Dtos.OrderDto> OrdersDtos { get; set; }

        public IndexModel(FS.EShopManagement.Public.Orders.IOrdersAppService fsOrdersAppService,
            ICurrentUser currentUser
        )
        {
            _fsOrdersAppService = fsOrdersAppService;
            _currentUser = currentUser;
            OrdersDtos = new PagedResultDto<FS.EShopManagement.Public.Orders.Dtos.OrderDto>();
        }
        public async Task OnGet()
        {
            FS.EShopManagement.Public.Orders.Dtos.GetOrder input = new FS.EShopManagement.Public.Orders.Dtos.GetOrder()
            {
                CustomerUserId = _currentUser.Id.Value,
                SkipCount = 0,
                MaxResultCount = 999,
            };            
            OrdersDtos = await this._fsOrdersAppService.GetListAsync(input);

        }
    }
}
