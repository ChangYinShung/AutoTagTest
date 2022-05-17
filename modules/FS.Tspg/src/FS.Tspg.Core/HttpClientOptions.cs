using System.Collections.Generic;

namespace FS.Tspg
{
    public class HttpClientOptions
    {
        public string Version { get; set; }

        public string Sender { get; set; }

        public string Currency { get; set; }

        public string MerchantId { get; set; }

        public string TerminalId { get; set; }

        public PayType PayType { get; set; }

        public bool Recommended { get; set; }

        public string BaseUrl { get; set; }

        public List<string> ExtraInfos { get; set; }

        public bool EnableLogger { get; set; }

        /// <summary>
        /// 銀行回呼網址，需組合PaymentId
        /// </summary>
        public string CallBackUrl { get; set; }

        public HttpClientOptions()
        {
            Version="1.0.0";

            Sender="rest";

            Currency = "NTD";

            Recommended=true;

            PayType = PayType.信用卡;

            ExtraInfos = new List<string>();

            EnableLogger=true;
        }
    }
}