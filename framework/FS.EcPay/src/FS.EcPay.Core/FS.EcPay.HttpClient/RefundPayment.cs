using System;
using System.Collections.Generic;
using System.Text;

namespace FS.EcPay.HttpClient
{
    public class RefundPayment
    {
        /// <summary>
        /// 特店交易編號
        /// </summary>
        public string PaymentNo { get; set; }

        /// <summary>
        /// 綠界交易編號 付款完成頁或查詢金流可取得
        /// </summary>
        public string EcPayPaymentNo { get; set; }

        /// <summary>
        /// 退刷金額
        /// </summary>
        public int Amount { get; set; }

    }
}
