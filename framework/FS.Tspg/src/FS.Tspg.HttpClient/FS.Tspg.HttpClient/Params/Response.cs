using System;
using System.Text.Json.Serialization;

namespace FS.Tspg.HttpClient.Params
{
    [Serializable]
    internal class Response<T> where T : IResponseParameter
    {
        [JsonPropertyName("ver")]
        public string Version { get; set; }
        [JsonPropertyName("mid")]
        public string MerchantId { get; set; }
        [JsonPropertyName("tid")]
        public string TerminalId { get; set; }
        [JsonPropertyName("pay_type")]
        public PayType PayType { get; set; }
        [JsonPropertyName("tx_type")]
        public TransactionType TransactionType { get; set; }

        /// <summary>
        /// <para>回傳值，不知為何台新文件沒有提到此欄位</para>
        /// <para>實際測試出來，此欄位不論什麼情形皆為0</para>
        /// </summary>
        [JsonPropertyName("ret_value")]
        public int ReturnValue { get; set; }
        [JsonPropertyName("params")]
        public virtual T Parameters { get; set; }
    }
}
