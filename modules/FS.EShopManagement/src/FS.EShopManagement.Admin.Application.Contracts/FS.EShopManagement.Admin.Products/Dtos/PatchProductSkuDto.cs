using System;
using System.Collections.Generic;
using System.Text;

namespace FS.EShopManagement.Admin.Products.Dtos
{
    public class PatchProductSkuDto //: EasyAbp.EShop.Products.Products.Dtos.UpdateProductSkuDto
    {
        public string Currency { get; set; }

        public decimal? OriginalPrice { get; set; }

        public decimal Price { get; set; }

        public int OrderMinQuantity { get; set; }

        public int OrderMaxQuantity { get; set; }

        public Guid? ProductDetailId { get; set; }

        public int InitialInventory { get; set; }

        public int PaymentExpireInMin { get; set; }
    }
}
