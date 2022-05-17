using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FS.EShopManagement.Orders
{
    public class OrderFilter : AutoFilterer.Types.FilterBase
    {
        [AutoFilterer.Attributes.CompareTo("OrderNumber", "TotalPrice")]
        public string Filter { get; set; }
    }
}
