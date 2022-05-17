namespace FS.Tspg.HttpClient.Dtos
{
    public class CreatePaymentResult
    {
        /// <summary>
        /// 銀行回傳代碼
        /// </summary>
        public string ReturnCode { get; set; }

        /// <summary>
        /// 銀行回傳訊息
        /// </summary>
        public string ReturnMessage { get; set; }

        /// <summary>
        /// 付款網址
        /// </summary>
        public string PaymentUrl { get; set; }        
    }
}
