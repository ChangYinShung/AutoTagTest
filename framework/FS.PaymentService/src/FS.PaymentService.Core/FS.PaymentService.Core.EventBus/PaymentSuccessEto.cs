using System;
using System.Collections.Generic;
using System.Text;

namespace FS.PaymentService.Core.EventBus
{
    public class PaymentSuccessEto
    {
        public string PaymentGateway { get; set; }

        public Guid PaymentId { get; set; }

        public string PaymentNo { get; set; }
    }
}
