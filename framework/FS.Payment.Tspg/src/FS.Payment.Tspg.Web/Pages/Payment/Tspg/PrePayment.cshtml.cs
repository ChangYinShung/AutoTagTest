using FS.Payment.Tspg.Pages.Payment.Tspg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Volo.Payment;
using Volo.Payment.Requests;
using FS.Tspg.HttpClient;
using Newtonsoft.Json;
using FS.Tspg;
using FS.Tspg.HttpClient.Dtos;

namespace FS.Payment.Tspg.Web.Pages.Payment.Tspg
{
    public class PrePaymentModel : PageModel
    {
        private readonly PaymentWebOptions paymentWebOptions;
        //private readonly PaymentOptions paymentGatewayOptions;
        private readonly HttpClientOptions tspgOptions;
        private readonly IPaymentRequestAppService paymentRequestAppService;
        private readonly TspgHttpClient tspgHttpClient;

        [BindProperty] public Guid PaymentRequestId { get; set; }


        public PrePaymentModel(
            IOptions<PaymentWebOptions> paymentWebOptions,
            //IOptions<PaymentOptions> paymentGatewayOptions,
            IPaymentRequestAppService paymentRequestAppService,
            TspgHttpClient tspgHttpClient,
            IOptions<HttpClientOptions> tspgOptions
            )
        {
            this.paymentWebOptions = paymentWebOptions.Value;
            //this.paymentGatewayOptions = paymentGatewayOptions.Value;
            this.paymentRequestAppService = paymentRequestAppService;
            this.tspgHttpClient = tspgHttpClient;

            this.tspgOptions = tspgOptions.Value;
        }

        public ActionResult OnGet()
        {
            return BadRequest();
        }

        public virtual async Task<ActionResult> OnPostAsync()
        {
            var paymentRequest = await this.paymentRequestAppService.GetAsync(this.PaymentRequestId);

            await this.paymentRequestAppService.SetCurrencyAsync(new SetPaymentRequestCurrencyDto()
            {
                Id = this.PaymentRequestId,
                Currency = this.tspgOptions.Currency
            });

            //var rootUrl = this.paymentWebOptions.RootUrl;
            var backUrl = this.paymentWebOptions.Gateways[TspgConsts.GatewayName].PostPaymentUrl;

            var tspg = this.getConfigurationFromExtraProperty(paymentRequest);

            var result = await this.tspgHttpClient.CreatePaymentAsync(new CreatePaymentRequest()
            {
                PaymentNo = tspg?.PaymentNo?.ToString() ?? DateTime.Now.ToString("yyyyMMddhhmmss"),
                Amount = (decimal)paymentRequest.TotalPrice,
                Currency = this.tspgOptions.Currency,
                PostBackUrl = $"{backUrl}/{this.PaymentRequestId}",
                PaymentId = this.PaymentRequestId.ToString()
                //WehHookUrl = $"{rootUrl}/webhook/{this.PaymentRequestId}",
            });

            return Redirect(result.PaymentUrl);
        }

        private TspgPaymentRequestExtraParameterConfiguration getConfigurationFromExtraProperty(PaymentRequestWithDetailsDto paymentRequest)
        {
            var hasKey = paymentRequest.ExtraProperties.ContainsKey(TspgConsts.GatewayName);
            if (!hasKey) return null;

            var json = paymentRequest.ExtraProperties[TspgConsts.GatewayName].ToString();
            var result = JsonConvert.DeserializeObject<TspgPaymentRequestExtraParameterConfiguration>(json);

            return result;
        }
    }
}
