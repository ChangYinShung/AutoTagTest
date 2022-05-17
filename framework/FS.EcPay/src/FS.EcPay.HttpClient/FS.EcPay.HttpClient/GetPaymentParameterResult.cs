using System;
using System.Collections.Generic;
using System.Text;

namespace FS.EcPay.HttpClient
{
    internal class GetPaymentParameterResult
    {
        /// <summary>
        /// 特店編號 String(10)
        /// </summary>
        public string MerchantID { get; set; }

        /// <summary>
        /// 特店交易編號 String(20)
        /// </summary>
        public string MerchantTradeNo { get; set; }

        /// <summary>
        /// 商店代號 String(20)
        /// </summary>
        public string StoreID { get; set; }

        /// <summary>
        /// 綠界的交易編號 String(20)
        /// </summary>
        public string TradeNo { get; set; }

        /// <summary>
        /// 交易金額
        /// </summary>
        public int? TradeAmt { get; set; }

        /// <summary>
        /// 付款時間 String(20)
        /// yyyy/MM/dd HH:mm:ss
        /// </summary>
        public string PaymentDate { get; set; }

        /// <summary>
        /// 付款方式 String(20)
        /// </summary>
        public string PaymentType { get; set; }

        /// <summary>
        /// 手續費合計
        /// </summary>
        public int? HandlingCharge { get; set; }

        /// <summary>
        /// 通路費
        /// </summary>
        public decimal? PaymentTypeChargeFee { get; set; }

        /// <summary>
        /// 金流成立時間 String(20)
        /// yyyy/MM/dd HH:mm:ss
        /// </summary>
        public string TradeDate { get; set; }

        /// <summary>
        /// 交易狀態 String(8)
        /// 若為 0 時，代表交易訂單成立未付款
        /// 若為 1 時，代表交易訂單成立已付款
        /// 若為 10200095 時，代表交易訂單未成立，消費者未完成付款作業，故交易失敗。
        /// </summary>
        public string TradeStatus { get; set; }

        /// <summary>
        /// 商品名稱 String(400)
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 授權交易單號
        /// </summary>
        public int? gwsr { get; set; }

        /// <summary>
        /// 卡片末4碼
        /// </summary>
        public string card4no { get; set; }

        /// <summary>
        /// 卡片前6碼
        /// </summary>
        public string card6no { get; set; }

        /// <summary>
        /// 授權碼
        /// </summary>
        public string auth_code { get; set; }

        /// <summary>
        /// 檢查碼
        /// </summary>
        public string CheckMacValue { get; set; }

        public GetPaymentResult GenerateResult()
        {
            return new GetPaymentResult()
            {
                PaymentNo = this.MerchantTradeNo,
                EcPayPaymentNo = this.TradeNo,
                CreditAuthorizedNo = this.gwsr,
                Amount = this.TradeAmt ?? 0,
                HandlingCharge = this.HandlingCharge ?? 0,
                CardLast4No = this.card4no,
                AuthCode = this.auth_code,
                IsSuccess = this.TradeStatus == "1"
            };
        }

    }
}
