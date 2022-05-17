using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace FS.EShopManagement.Public.Products.Dtos
{
    public class GetProductViewListInput : PagedAndSortedResultRequestDto
    {
        [Required]
        public Guid StoreId { get; set; }

        public List<Guid> CategoryIds { get; set; }

        public string Filter { get; set; }
    }
}
