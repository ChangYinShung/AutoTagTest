namespace FS.Tspg.HttpClient.Dtos
{
    public class GetPaymentResult
    {
        public string ReturnCode { get; set; }
        public string ReturnMessage { get; set; }

        #region 查詢訂單細節

        /// <summary>
        /// 狀態訂單碼
        /// </summary>
        public string OrderStatus { get; set; }


        /// <summary>
        /// 幣別
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// <para>交易金額</para>
        /// </summary>
        public decimal TransactionAmount { get; set; }

        /// <summary>
        /// 授權碼
        /// </summary>
        public string AuthorizeIdResponse { get; set; }

        /// <summary>
        /// <para>退貨金額</para>
        /// </summary>
        public decimal RefundTransAmount { get; set; }

        #endregion 查詢訂單細節
    }
}
