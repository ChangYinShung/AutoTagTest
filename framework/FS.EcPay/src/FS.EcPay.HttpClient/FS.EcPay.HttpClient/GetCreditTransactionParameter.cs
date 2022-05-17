using System;
using System.Collections.Generic;
using System.Text;

namespace FS.EcPay.HttpClient
{
    internal class GetCreditTransactionParameter : EcPayParameterBase
    {
        public override string Query => "QueryTrade";

        /// <summary>
        /// 特店編號 String(10)
        /// </summary>
        public string MerchantID { get; set; }

        /// <summary>
        /// 信用卡授權單號
        /// </summary>
        public int CreditRefundId { get; set; }

        /// <summary>
        /// 金額
        /// </summary>
        public int CreditAmount { get; set; }

        /// <summary>
        /// 商家檢查碼
        /// </summary>
        public int CreditCheckCode { get; set; }

        public GetCreditTransactionParameter(
            GetCreditTransaction input,
            HttpClientOptions options)
        {
            this.MerchantID = options.MerchantId;
            this.CreditRefundId = input.CreditAuthorNo;
            this.CreditAmount = input.CreditAmount;
            this.CreditCheckCode = options.CreditCheckCode;

            this.SetCheckMacValue(options);
        }

    }
}
