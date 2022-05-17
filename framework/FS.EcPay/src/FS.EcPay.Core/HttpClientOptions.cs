using System;
using System.Collections.Generic;
using System.Text;

namespace FS.EcPay
{
    public class HttpClientOptions
    {
        /// <summary>
        /// Ec Pay Api Url
        /// </summary>
        public string EcPayApiUrl { get; set; }

        /// <summary>
        /// Ec Pay Api Version
        /// </summary>
        public string EcPayApiUrlVersion { get; set; }

        /// <summary>
        /// 特店編號
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// 加密使用參數，加密時加在最前
        /// </summary>
        public string HashKey { get; set; }

        /// <summary>
        /// 加密使用參數，加密時加在最後
        /// </summary>
        public string HashIV { get; set; }

        /// <summary>
        /// 商家檢查碼
        /// 廠商後台->信用卡收單->信用卡授權資訊中可查到。
        /// </summary>
        public int CreditCheckCode { get; set; }

        /// <summary>
        /// 銀行回呼網址，需組合PaymentId
        /// </summary>
        public string CallBackUrl { get; set; }
    }
}
