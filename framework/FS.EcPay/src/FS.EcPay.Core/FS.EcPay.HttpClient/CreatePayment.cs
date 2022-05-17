using System;
using System.Collections.Generic;
using System.Text;

namespace FS.EcPay.HttpClient
{
    public class CreatePayment
    {
        /// <summary>
        /// 特店交易代號 PostPaymentUrl, WebhookUrl 使用
        /// </summary>
        public string PaymentId { get; set; }

        /// <summary>
        /// 特店交易編號
        /// </summary>
        public string PaymentNo { get; set; }

        /// <summary>
        /// 付款時間
        /// </summary>
        public DateTime PaymentDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 交易金額
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 交易描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 商品名稱
        /// </summary>
        public List<string> ItemNames { get; set; }
    }
}
