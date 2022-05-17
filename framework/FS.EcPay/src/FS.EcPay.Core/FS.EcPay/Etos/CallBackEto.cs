using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.EcPay.Etos
{
    public class CallBackEto : Dtos.CallBackDto
    {
        public string PaymentId { get; set; }
    }

}
