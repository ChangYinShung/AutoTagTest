using System.Text.Json.Serialization;

namespace FS.Tspg.Etos;

public class CallBackEto : Dtos.CallBackDto
{
    public string PaymentGateway { get; set; }

    public string PaymentId { get; set; }
}
