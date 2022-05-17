using System;
using System.Collections.Generic;
using System.Text;

namespace FS.EcPay.HttpClient
{
    internal enum RefundAction
    {
        C,
        R,
        E,
        N
    }

    internal class RefundPaymentParameter : EcPayParameterBase
    {
        public override string Query => "DoAction";

        /// <summary>
        /// 特店編號 String(10)
        /// </summary>
        public string MerchantID { get; set; }

        /// <summary>
        /// 特店交易編號 String(20)
        /// </summary>
        public string MerchantTradeNo { get; set; }

        /// <summary>
        /// 綠界交易編號 String(20)
        /// </summary>
        public string TradeNo { get; set; }


        /// <summary>
        /// 執行動作 enum RefundAction
        /// C︰關帳，可由綠界後台設定自動關帳(信用卡收單->信用卡帳戶設定->每日自動關帳)
        /// R︰退刷
        /// E︰取消
        /// N︰放棄
        /// 若開啟自動關帳，則每日 20:15 ~ 20:30 不可使用此 API
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 金額
        /// </summary>
        public int TotalAmount { get; set; }

        public RefundPaymentParameter(
            RefundPayment input,
            HttpClientOptions options,
            RefundAction action)
        {
            this.MerchantID = options.MerchantId;
            this.MerchantTradeNo = input.PaymentNo;
            this.TradeNo = input.EcPayPaymentNo;
            this.Action = action.ToString();
            this.TotalAmount = input.Amount;

            this.SetCheckMacValue(options);
        }
    }
}
