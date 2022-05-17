using FS.Tspg;
using FS.Tspg.HttpClient.Dtos;
using System.Text.Json.Serialization;

namespace FS.Tspg.HttpClient.Params
{
    internal class CreatePaymentResultParameter : IResponseParameter
    {
        [JsonPropertyName("ret_code")]
        public string ReturnCode { get; set; }

        [JsonPropertyName("ret_msg")]
        public string ReturnMessage { get; set; }

        [JsonPropertyName("hpp_url")]
        public string HttpUrl { get; set; }


        public CreatePaymentResult ConvertToCreatePaymentResult()
        {
            return new CreatePaymentResult()
            {
                ReturnCode = ReturnCode,
                ReturnMessage = ReturnMessage,
                PaymentUrl = HttpUrl
            };
        }

        public void Validate()
        {
            this.DefaultValidate();
        }
    }
}
