using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace FS.EShopManagement.Public.Products.Dtos
{
    public class GetProductWithDetail : PagedAndSortedResultRequestDto
    {
        public Guid StoreId { get; set; }

        public List<Guid> CategoryIds { get; set; }

        public string Filter { get; set; }
    }
}
