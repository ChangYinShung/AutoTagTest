using System;
using System.Collections.Generic;
using System.Text;

namespace FS.EcPay.HttpClient
{
    public class GetPaymentResult
    {
        /// <summary>
        /// 特店交易編號 String(20)
        /// </summary>
        public string PaymentNo { get; set; }

        /// <summary>
        /// 綠界的交易編號 String(20)
        /// </summary>
        public string EcPayPaymentNo { get; set; }

        /// <summary>
        /// 授權交易單號
        /// </summary>
        public int? CreditAuthorizedNo { get; set; }

        /// <summary>
        /// 交易金額
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 手續費合計
        /// </summary>
        public int HandlingCharge { get; set; }

        /// <summary>
        /// 卡片末4碼
        /// </summary>
        public string CardLast4No { get; set; }

        /// <summary>
        /// 授權碼
        /// </summary>
        public string AuthCode { get; set; }

        /// <summary>
        /// 是否為成功交易
        /// </summary>
        public bool IsSuccess { get; set; }
    }
}
