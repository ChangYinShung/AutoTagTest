namespace FS.Tspg.HttpClient.Dtos
{
    public class CreatePaymentRequest
    {
        public string PaymentNo { get; set; }
        
        public decimal Amount { get; set; }
        
        public string Currency { get; set; }
        
        public string PostBackUrl { get; set; }
        
        public string PaymentId { get; set; }
        //public string WehHookUrl { get; set; }
    }
}
