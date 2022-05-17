using System;
using System.Collections.Generic;
using System.Text;

namespace FS.EShopManagement.Admin.Orders.Dtos
{
    public class OrderCompleteAndSetReceipt
    {
        public Guid OrderId { get; set; }

        public string Receipt { get; set; }
    }
}
