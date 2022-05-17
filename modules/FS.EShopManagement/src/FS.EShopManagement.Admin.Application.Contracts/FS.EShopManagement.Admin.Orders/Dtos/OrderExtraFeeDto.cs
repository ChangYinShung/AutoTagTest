using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace FS.EShopManagement.Admin.Orders.Dtos
{
    public class OrderExtraFeeDto: EntityDto
    {
        public virtual Guid OrderId { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual string Key { get; protected set; }

        public virtual decimal Fee { get; protected set; }
    }
}
