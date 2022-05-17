using System;
using System.Collections.Generic;
using System.Text;

namespace FS.PaymentService
{
    public class PaymentServiceOptions
    {
        //public string GatewayName { get; set; }
        public string PrePayUrl { get; set; }
        public string PostPayUrl { get; set; }
        public bool UiEnabled { get; set; }
    }
}
