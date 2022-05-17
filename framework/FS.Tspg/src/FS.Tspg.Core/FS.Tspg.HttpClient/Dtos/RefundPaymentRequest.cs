namespace FS.Tspg.HttpClient.Dtos
{
    public class RefundPaymentRequest
    {
        public string PaymentNo { get; set; }
        public decimal RefundAmount { get; set; }
    }
}
