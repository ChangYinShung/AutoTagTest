using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FS.EcPay.HttpClient
{
    internal class GetPaymentParameter : EcPayParameterBase
    {
        public override string Query => "QueryTradeInfo";

        /// <summary>
        /// 特店編號
        /// </summary>
        public string MerchantID { get; set; }

        /// <summary>
        /// 特店交易編號
        /// </summary>
        public string MerchantTradeNo { get; set; }

        /// <summary>
        /// 驗證時間
        /// Submit Post 時間需為此時間的 3 分內，否則會查詢失敗
        /// </summary>
        public int TimeStamp { get; set; }

        public GetPaymentParameter(
            GetPayment input,
            HttpClientOptions options)
        {
            this.MerchantID = options.MerchantId;
            this.MerchantTradeNo = input.PaymentNo;
            this.TimeStamp = (int)((DateTimeOffset)input.Date).ToUnixTimeSeconds();

            this.SetCheckMacValue(options);
        }
    }
}
