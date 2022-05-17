using System;

namespace CFTA.Web.Public.Models
{
    public class ShopCheckoutItemModel
    {
        public Guid StoreId { get; set; }

        public Guid ProductId { get; set; }

        public Guid ProductSkuId { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 目前請填寫背號
        /// </summary>
        public string Remark { get; set; }
    }
}