using System;
using System.Collections.Generic;
using System.Text;

namespace FS.EcPay.HttpClient
{
    public class GetPayment
    {
        public string PaymentNo { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
