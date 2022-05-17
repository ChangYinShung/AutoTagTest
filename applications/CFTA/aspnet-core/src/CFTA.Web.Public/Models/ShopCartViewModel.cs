using System;

namespace CFTA.Web.Public.Models
{
    public class ShopCartViewModel
    {
        public Guid ProductId { get; set; }
        public Guid ProductSkuId { get; set; }
        public string ProductName { get; set; }
        public string ProductSkuName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Remark { get; set; }
        public int Amount
        {
            get { return Quantity * Price; }
        }
    }
}
