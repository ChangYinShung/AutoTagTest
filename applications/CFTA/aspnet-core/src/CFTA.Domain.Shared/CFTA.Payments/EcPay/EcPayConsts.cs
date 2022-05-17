using System;
using System.Collections.Generic;
using System.Text;

namespace CFTA.Payments.EcPay
{
    public class EcPayConsts
    {
        /// <summary>
        /// 對應 FS.Tspg.PaymentService.PaymentMethod
        /// </summary>
        public const string GatewayName = "EcPay";

        /// <summary>
        /// UI 顯示名稱
        /// </summary>
        public const string GatewayDisplayName = "信用卡";

        /// <summary>
        /// UI 導至付款頁
        /// </summary>
        public const string PrePaymentUrl = "/e-shop/payment-service/ec-pay/pre-payment";

        /// <summary>
        /// UI 付款導回頁
        /// </summary>
        public const string PostPaymentUrl = "/e-shop/payment-service/ec-pay/post-payment";
    }
}
