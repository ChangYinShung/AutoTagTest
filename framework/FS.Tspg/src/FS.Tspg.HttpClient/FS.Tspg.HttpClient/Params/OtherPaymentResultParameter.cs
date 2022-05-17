using FS.Tspg;
using FS.Tspg.HttpClient.Dtos;
using System.Text.Json.Serialization;

namespace FS.Tspg.HttpClient.Params
{
    internal class OtherPaymentResultParameter : IResponseParameter
    {
        [JsonPropertyName("ret_code")]
        public string ReturnCode { get; set; }

        [JsonPropertyName("ret_msg")]
        public string ReturnMessage { get; set; }

        public CancelPaymentResult ConvertToCancelPaymentResult()
        {
            return new CancelPaymentResult()
            {
                ReturnCode = ReturnCode,
                ReturnMessage = ReturnMessage
            };
        }
        public RefundPaymentResult ConvertToRefundPaymentResult()
        {
            return new RefundPaymentResult()
            {
                ReturnCode = ReturnCode,
                ReturnMessage = ReturnMessage
            };
        }

        public void Validate()
        {
            this.DefaultValidate();
        }
    }
    public class OtherPaymentResultParameterWithDetail : IResponseParameter
    {
        [JsonPropertyName("ret_code")]
        public string ReturnCode { get; set; }

        [JsonPropertyName("ret_msg")]
        public string ReturnMessage { get; set; }

        #region 查詢訂單細節

        /// <summary>
        /// 狀態訂單碼
        /// </summary>
        [JsonPropertyName("order_status")]
        public string OrderStatus { get; set; }

        /// <summary>
        /// 授權方式(SSL/3D)
        /// </summary>
        [JsonPropertyName("auth_type")]
        public string AuthType { get; set; }

        /// <summary>
        /// 幣別
        /// </summary>
        [JsonPropertyName("cur")]
        public string Currency { get; set; }

        /// <summary>
        /// 採購日期
        /// </summary>
        [JsonPropertyName("purchase_date")]
        public string PurchaseDate { get; set; }

        /// <summary>
        /// <para>交易金額，包含兩位小數</para>
        /// <para>如100代表1.00元</para>
        /// </summary>
        [JsonPropertyName("tx_amt")]
        public string TransactionAmount { get; set; }

        /// <summary>
        /// 授權碼
        /// </summary>
        [JsonPropertyName("auth_id_resp")]
        public string AuthorizeIdResponse { get; set; }

        /// <summary>
        /// 調單號碼
        /// </summary>
        [JsonPropertyName("rrn")]
        public string Rrn { get; set; }

        /// <summary>
        /// <para>請款金額，包含兩位小數</para>
        /// <para>如100代表1.00元</para>
        /// </summary>
        [JsonPropertyName("settle_amt")]
        public string SettleAmount { get; set; }

        /// <summary>
        /// <para>退貨金額，包含兩位小數</para>
        /// <para>如100代表1.00元</para>
        /// </summary>
        [JsonPropertyName("refund_trans_amt")]
        public string RefundTransAmount { get; set; }

        /// <summary>
        /// 折抵點數
        /// </summary>
        [JsonPropertyName("redeem_pt")]
        public string RedeemPoint { get; set; }

        /// <summary>
        /// <para>折抵金額，包含兩位小數</para>
        /// <para>如100代表1.00元</para>
        /// </summary>
        [JsonPropertyName("redeem_amt")]
        public string RedeemAmount { get; set; }

        /// <summary>
        /// <para>實付金額，包含兩位小數</para>
        /// <para>如100代表1.00元</para>
        /// </summary>
        [JsonPropertyName("post_redeem_amt")]
        public string PostRedeemAmount { get; set; }

        /// <summary>
        /// 剩餘點數
        /// </summary>
        [JsonPropertyName("post_redeem_pt")]
        public string PostRedeemPoint { get; set; }

        /// <summary>
        /// <para>首期金額，包含兩位小數</para>
        /// <para>如100代表1.00元</para>
        /// </summary>
        [JsonPropertyName("install_down_pay")]
        public string InstallDownPay { get; set; }

        /// <summary>
        /// <para>每期金額，包含兩位小數</para>
        /// <para>如100代表1.00元</para>
        /// </summary>
        [JsonPropertyName("install_pay")]
        public string InstallPay { get; set; }

        #endregion 查詢訂單細節

        public GetPaymentResult ConvertToGetPaymentResult()
        {
            return new GetPaymentResult()
            {
                AuthorizeIdResponse = AuthorizeIdResponse,
                Currency = Currency,
                ReturnCode = ReturnCode,
                RefundTransAmount = RefundTransAmount.AmountStrToDecimalFloored(),
                OrderStatus = OrderStatus,
                ReturnMessage = ReturnMessage,
                TransactionAmount = TransactionAmount.AmountStrToDecimalFloored(),
            };
        }

        public void Validate()
        {
            this.DefaultValidate();
        }
    }
}
