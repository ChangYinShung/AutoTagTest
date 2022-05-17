using System;
using System.Text.Json.Serialization;

namespace FS.Tspg.HttpClient.Params
{
    [Serializable]
    internal class Request<T>
    {
        [JsonPropertyName("sender")]
        public string Sender { get; set; }
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
        [JsonPropertyName("params")]
        public virtual T Parameters { get; set; }
    }
}
