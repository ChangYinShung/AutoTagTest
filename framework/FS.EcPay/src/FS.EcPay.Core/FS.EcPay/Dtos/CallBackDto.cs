using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.EcPay.Dtos
{
    public class CallBackDto
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
        /// 交易狀態
        /// </summary>
        public int? RtnCode { get; set; }

        /// <summary>
        /// 交易訊息
        /// </summary>
        public string RtnMsg { get; set; }

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
        /// 金流成立時間 String(20)
        /// yyyy/MM/dd HH:mm:ss
        /// </summary>
        public string TradeDate { get; set; }

        /// <summary>
        /// 是否為模擬付款
        /// </summary>
        public int? SimulatePaid { get; set; }

        /// <summary>
        /// 自訂名稱欄位1
        /// </summary>
        public string CustomField1 { get; set; }

        /// <summary>
        /// 自訂名稱欄位2
        /// </summary>
        public string CustomField2 { get; set; }

        /// <summary>
        /// 自訂名稱欄位3
        /// </summary>
        public string CustomField3 { get; set; }

        /// <summary>
        /// 自訂名稱欄位4
        /// </summary>
        public string CustomField4 { get; set; }

        /// <summary>
        /// 檢查碼
        /// </summary>
        public string CheckMacValue { get; set; }

        public bool IsSuccess
        {
            get
            {
                return RtnCode == 1;
            }
        }
    }
}
