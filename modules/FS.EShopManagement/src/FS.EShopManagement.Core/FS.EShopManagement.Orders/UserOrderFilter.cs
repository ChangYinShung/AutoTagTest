using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FS.EShopManagement.Orders
{
    public class UserOrderFilter : AutoFilterer.Types.FilterBase
    {
        [AutoFilterer.Attributes.CompareTo("CustomerUserId")]
        [AutoFilterer.Attributes.StringFilterOptions(AutoFilterer.Enums.StringFilterOption.Equals)]
        public Guid CustomerUserId { get; set; }
    }
}
