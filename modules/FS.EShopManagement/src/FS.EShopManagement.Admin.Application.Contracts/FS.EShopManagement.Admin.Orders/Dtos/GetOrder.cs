using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace FS.EShopManagement.Admin.Orders.Dtos
{
    public class GetOrder : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }

}
