namespace FS.Tspg.HttpClient.Dtos
{
    public class CancelPaymentResult
    {
        public bool IsSuccess { get; set; }
        public string ReturnMessage { get; set; }
        public string ReturnCode { get; set; }
    }
}