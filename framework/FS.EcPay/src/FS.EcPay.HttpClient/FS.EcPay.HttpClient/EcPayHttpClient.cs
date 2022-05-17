using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FS.EcPay.HttpClient
{
    public class EcPayHttpClient : Volo.Abp.DependencyInjection.ITransientDependency, IEcPayHttpClient
    {
        private readonly HttpClientOptions httpClientOptions;

        public EcPayHttpClient(
            IOptions<HttpClientOptions> httpClientOptions,
            ILogger<EcPayHttpClient> logger
            )
        {
            //var loggerWraper = new LoggerWraper<TspgHttpClient>(logger);

            this.httpClientOptions = httpClientOptions.Value;

            //var options = new RestClientOptions(tspgOptions.Value.BaseUrl);

            //if (tspgOptions.Value.EnableLogger)
            //    options.ConfigureMessageHandler = handler => new HttpTracerHandler(handler, loggerWraper, HttpMessageParts.All);
        }

        /// <summary>
        /// 建立金流
        /// </summary>
        public Task<string> CreatePaymentAsync(string postPayUrl, CreatePayment input)
        {
            var parameters = new CreatePaymentParameter(input, this.httpClientOptions, postPayUrl);
            return Task.FromResult(parameters.GetFormPostHtml(this.httpClientOptions));
        }

        /// <summary>
        /// 查詢金流
        /// </summary>
        public async Task<GetPaymentResult> GetPaymentAsync(GetPayment input)
        {
            var parameters = new GetPaymentParameter(input, this.httpClientOptions);

            var response = await parameters.ExecuteRestClientAsync<GetPaymentParameterResult>(this.httpClientOptions);

            return response.GenerateResult();
        }

        /// <summary>
        /// 查詢信用卡交易
        /// 測試站無法使用
        /// </summary>
        public Task<string> GetCreditTransactionAsync(GetCreditTransaction input)
        {
            var parameters = new GetCreditTransactionParameter(input, this.httpClientOptions);
            return Task.FromResult(parameters.GetFormPostHtml(this.httpClientOptions));
        }

        /// <summary>
        /// 退刷金流
        /// 測試站無法使用
        /// </summary>
        public Task<string> RefundPaymentAsync(RefundPayment input)
        {
            // 1. 查詢信用卡授權狀態 GetCreditTransactionAsync
            // 2. 依授權狀態退刷
            //   a. 已授權︰RefundAction.N
            //   b. 要關帳︰
            //     b1. 全額退刷︰RefundAction.E -> RefundAction.N
            //     b2. 部分退刷︰RefundAction.R
            //   c. 已關帳︰RefundAction.R

            return Task.FromResult("");
        }
    }
}
