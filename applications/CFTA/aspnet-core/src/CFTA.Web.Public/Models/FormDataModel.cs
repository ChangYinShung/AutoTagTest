using System.Collections.Generic;

namespace CFTA.Web.Public.Models
{
    public class FormDataModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string NonTaiwanCity { get; set; }

        public string TaiwanZipCode { get; set; }

        public string TaiwanCity { get; set; }

        public string TaiwanArea { get; set; }

        public string Address { get; set; }

        public string Remark { get; set; }

        public List<FormDataSkuWithStoreId> SkuItems { get; set; }

        public string PaymentGroup { get; set; }

        public string FullAddress 
        { 
            get
            {
                var address = this.Address;
                switch (this.Country)
                {
                    case "Taiwan":
                        address = this.TaiwanZipCode + this.TaiwanCity + this.TaiwanArea + address;
                        break;
                    default:
                        address = this.NonTaiwanCity + address;
                        break;
                }

                return address;
            } 
        }
    }

    public class FormDataSkuWithStoreId
    {
        public string SkuId { get; set; }

        public string ProductId { get; set; }

        public int Quantity { get; set; }

        public string RemarkExtraFee { get; set; }

        public string Remark { get; set; }

        public string StoreId { get; set; }

        public string SkuName { get; set; }
    }
}
