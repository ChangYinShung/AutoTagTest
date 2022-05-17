using System;
using System.Collections.Generic;
using System.Text;

namespace FS.EcPay.HttpClient
{
    public class GetCreditTransaction
    {
        /// <summary>
        /// 信用卡授權單號
        /// </summary>
        public int CreditAuthorNo { get; set; }

        /// <summary>
        /// 金額
        /// </summary>
        public int CreditAmount { get; set; }
    }
}
