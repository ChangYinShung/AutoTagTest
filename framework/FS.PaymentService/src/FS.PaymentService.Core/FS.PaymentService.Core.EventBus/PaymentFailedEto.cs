using System;
using System.Collections.Generic;
using System.Text;

namespace FS.PaymentService.Core.EventBus
{
    public class PaymentFailedEto
    {
        public string PaymentGateway { get; set; }

        public Guid PaymentId { get; set; }

        public string PaymentNo { get; set; }

        public string Message { get; set; }

        public string Code { get; set; }
    }
}
