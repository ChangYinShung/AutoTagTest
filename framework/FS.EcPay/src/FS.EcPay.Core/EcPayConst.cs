using System;
using System.Collections.Generic;
using System.Text;

namespace FS.EcPay
{
    public class EcPayConst
    {
        /// <summary>
        /// 預設付款方式，目前僅使用信用卡，如需其他付款方式請查看文件
        /// </summary>
        public const string ChoosePayment = "Credit";

        /// <summary>
        /// 加密方式，1︰sha256
        /// </summary>
        public const int EncryptType = 1;

        /// <summary>
        /// 交易類型，文件表明固定為 aio
        /// </summary>
        public const string PaymentType = "aio";

        /// <summary>
        /// 是否需要額外的付款資訊
        /// </summary>
        public const string NeedExtraPaidInfo = "Y";
    }
}
