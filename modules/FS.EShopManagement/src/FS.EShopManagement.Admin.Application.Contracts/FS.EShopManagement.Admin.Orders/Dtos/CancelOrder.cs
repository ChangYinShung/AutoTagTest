using System;
using System.Collections.Generic;
using System.Text;

namespace FS.EShopManagement.Admin.Orders.Dtos
{
    public class CancelOrder
    {
        public Guid OrderId { get; set; }

        public string DisplayReason { get; set; }
    }
}
