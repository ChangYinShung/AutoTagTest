using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace FS.EShopManagement.Public.Orders.Dtos
{

    public class GetOrder : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public Guid CustomerUserId { get; set; }
    }

}
