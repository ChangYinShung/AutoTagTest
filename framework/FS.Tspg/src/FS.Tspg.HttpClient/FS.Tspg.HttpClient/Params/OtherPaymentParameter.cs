using FS.Tspg;
using FS.Tspg.HttpClient.Dtos;
using System.Text.Json.Serialization;

namespace FS.Tspg.HttpClient.Params
{
    internal class OtherPaymentParameter
    {
        [JsonPropertyName("order_no")]
        public string OrderNo { get; set; }

        [JsonPropertyName("amt")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Amount { get; set; }

        [JsonPropertyName("result_flag")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ResultFlag { get; set; }


        /// <summary>
        /// 查詢訂單
        /// </summary>
        /// <param name="request"></param>
        public OtherPaymentParameter(GetPaymentRequest request)
        {
            const string 查詢交易詳情 = "1";

            ResultFlag = 查詢交易詳情;
            OrderNo = request.PaymentNo;
        }

        /// <summary>
        /// 取消授權訂單
        /// </summary>
        /// <param name="request"></param>
        public OtherPaymentParameter(CancelPaymentRequest request)
        {
            OrderNo = request.PaymentNo;
        }

        /// <summary>
        /// 退刷訂單
        /// </summary>
        /// <param name="request"></param>
        public OtherPaymentParameter(RefundPaymentRequest request)
        {
            OrderNo = request.PaymentNo;
            Amount = request.RefundAmount.ToAmountStrFloored();
        }
    }
}
