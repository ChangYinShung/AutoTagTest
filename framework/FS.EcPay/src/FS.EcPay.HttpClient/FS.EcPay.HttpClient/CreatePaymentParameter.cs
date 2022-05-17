using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FS.EcPay.HttpClient
{
    internal class CreatePaymentParameter : EcPayParameterBase
    {
        public override string Query => "AioCheckOut";

        /// <summary>
        /// 特店編號 String(10)
        /// </summary>
        public string MerchantID { get; set; }

        /// <summary>
        /// 特店交易編號 String(20)
        /// </summary>
        public string MerchantTradeNo { get; set; }

        /// <summary>
        /// 特店交易時間 String(20)
        /// yyyy/MM/dd HH:mm:ss
        /// </summary>
        public string MerchantTradeDate { get; set; }

        /// <summary>
        /// 交易類型 String(20)
        /// </summary>
        public string PaymentType { get; set; }

        /// <summary>
        /// 交易金額
        /// </summary>
        public int TotalAmount { get; set; }

        /// <summary>
        /// 交易描述 String(200)
        /// 不可有特殊字元
        /// </summary>
        public string TradeDesc { get; set; }

        /// <summary>
        /// 商品名稱，多筆則以 # 分隔 String(400)
        /// 如︰手機20元X2#隨身碟60元X1
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 付款完成通知回傳網址，Webhook String(200)
        /// </summary>
        public string ReturnURL { get; set; }

        /// <summary>
        /// 選擇預設付款方式 String(20)
        /// </summary>
        public string ChoosePayment { get; set; }

        /// <summary>
        /// Client端返回特店的按鈕連結 String(200)
        /// </summary>
        public string ClientBackURL { get; set; }

        /// <summary>
        /// CheckMacValue加密類型，請固定填入1，使用SHA256加密
        /// </summary>
        public int EncryptType { get; set; }

        /// <summary>
        /// 是否需要額外的付款資訊
        /// 付款方式為 Credit 時，會回傳 CreditRefundId 信用卡授權單號(後續查詢信用卡交易明細時使用)
        /// </summary>
        public string NeedExtraPaidInfo { get; set; }


        public CreatePaymentParameter(
            CreatePayment input,
            HttpClientOptions httpClientOptions,
            string postPayUrl)
        {
            this.MerchantID = httpClientOptions.MerchantId;
            this.MerchantTradeNo = input.PaymentNo;
            this.MerchantTradeDate = input.PaymentDate.ToString("yyyy/MM/dd HH:mm:ss");
            this.PaymentType = EcPayConst.PaymentType;
            this.TotalAmount = input.Amount;
            this.TradeDesc = input.Description;
            this.ItemName = String.Join("#", input.ItemNames);
            this.ReturnURL = $"{httpClientOptions.CallBackUrl}/{input.PaymentId}";
            this.ChoosePayment = EcPayConst.ChoosePayment;
            this.ClientBackURL = $"{postPayUrl}/{input.PaymentId}";
            this.EncryptType = EcPayConst.EncryptType;
            this.NeedExtraPaidInfo = EcPayConst.NeedExtraPaidInfo;

            this.SetCheckMacValue(httpClientOptions);
        }
    }
}
