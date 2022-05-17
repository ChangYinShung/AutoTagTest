using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Tspg.HttpClient
{
    internal static class TspgValueConverter
    {
        /// <summary>
        /// <para>TSPG數值字串轉換成decimal (小數點捨去)</para>
        /// <para>ex: 字串顯示 "12000",會轉換成 120 </para>
        /// </summary>
        /// <param name="amountStr"></param>
        /// <returns></returns>
        public static decimal AmountStrToDecimalFloored(this string amountStr)
        {
            var amountWithDecimal = decimal.Parse(amountStr);
            var amount = Math.Floor(amountWithDecimal / 100);

            return amount;
        }

        /// <summary>
        /// <para>decimal轉換成TSPG數值字串 (小數點捨去)</para>
        /// <para>ex: 數值120 會轉換成字串 "12000" </para>
        /// </summary>
        /// <param name="amountStr"></param>
        /// <returns></returns>
        public static string ToAmountStrFloored(this decimal amount)
        {
            var amountStr = ((int)amount).ToString() + "00";
            return amountStr;
        }
    }
}
