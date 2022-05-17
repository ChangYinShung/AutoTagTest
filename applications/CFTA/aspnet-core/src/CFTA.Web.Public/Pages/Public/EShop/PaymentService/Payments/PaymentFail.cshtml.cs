using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Volo.Payment.Requests;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Volo.Payment;

namespace CFTA.Pages.EShop.PaymentService.Payments
{
    public class PaymentFailModel : PageModel
    {
        public string ErrorMessage { get; set; }

        public void OnGet(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
        }

    }
}
