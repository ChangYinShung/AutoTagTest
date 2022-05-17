using System;
using System.Collections.Generic;
using System.Text;

namespace FS.EShopManagement.Public.Products.Dtos
{
    public class TestProductSkusDto
    {
        public Guid StoreId { get; set; }
        public Guid ProductId { get; set; }
        public Guid ProductSkuId { get; set; }
        public string ProductName { get; set; }
        public string ProductSkuName { get; set; }
        public int Price { get; set; }
    }
}
