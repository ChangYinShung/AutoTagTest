using FS.Tspg;
using FS.Tspg.HttpClient.Dtos;
using System.Text.Json.Serialization;

namespace FS.Tspg.HttpClient.Params
{
    internal class CreatePaymentParameter
    {
        [JsonPropertyName("layout")]
        public string Layout { get; set; } = "1";
        [JsonPropertyName("order_no")]
        public string OrderNo { get; set; }
        [JsonPropertyName("amt")]
        public string Amount { get; set; }

        /// <summary>
        /// 幣別，新台幣請填"NTD"
        /// </summary>
        [JsonPropertyName("cur")]
        public string Currency { get; set; }
        [JsonPropertyName("order_desc")]
        public string OrderDescription { get; set; }

        /// <summary>
        /// 授權同步請款標記
        ///0:不同步請款
        ///1:同步請款
        /// </summary>
        [JsonPropertyName("capt_flag")]
        public string CaptFlag { get; set; } = "0";
        [JsonPropertyName("result_flag")]
        public string ResultFlag { get; set; } = "1";
        [JsonPropertyName("post_back_url")]
        public string PostBackUrl { get; set; }
        [JsonPropertyName("result_url")]
        public string ResultUrl { get; set; }

        public CreatePaymentParameter(string callbackUrl, CreatePaymentRequest request)
        {
            OrderNo = request.PaymentNo;
            //Amount支援小數點2位，但是目前不需要
            Amount = request.Amount.ToAmountStrFloored();
            Currency = request.Currency;
            PostBackUrl = request.PostBackUrl;
            ResultUrl = callbackUrl;
        }
    }
}
