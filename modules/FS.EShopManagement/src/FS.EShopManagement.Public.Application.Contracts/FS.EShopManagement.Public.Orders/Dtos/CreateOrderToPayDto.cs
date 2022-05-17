using EasyAbp.EShop.Orders.Orders.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.ObjectExtending;

namespace FS.EShopManagement.Public.Orders.Dtos
{
    public class CreateOrderToPayDto
    {
        public List<CreateOrderDto> CreateOrders { get; set; }

        public ExtensibleObject PaymentProperties { get; set; }

        public string PaymentMethod { get; set; }
    }
}
