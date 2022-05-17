using FS.Tspg.HttpClient.Dtos;
using FS.Tspg.HttpClient.Params;
using HttpTracer;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FS.Tspg.HttpClient
{
    public class LoggerWraper<T> : HttpTracer.Logger.ILogger
    {
        private readonly ILogger<T> logger;

        public LoggerWraper(
            ILogger<T> logger)
        {
            this.logger=logger;
        }
        public void Log(string message)
        {
            this.logger.LogInformation(message);
        }
    }

    public class TspgHttpClient : Volo.Abp.DependencyInjection.ISingletonDependency, ITspgHttpClient
    {
        private RestClient restClient;
        private const string 信用卡授權交易Resource = "auth.ashx";
        private const string 其他交易Resource = "other.ashx";
        private readonly HttpClientOptions tspgOptions;

        public TspgHttpClient(
            IOptions<HttpClientOptions> tspgOptions,
            ILogger<TspgHttpClient> logger
            )
        {
            var loggerWraper = new LoggerWraper<TspgHttpClient>(logger);

            this.tspgOptions = tspgOptions.Value;

            var options = new RestClientOptions(tspgOptions.Value.BaseUrl);

            if (tspgOptions.Value.EnableLogger)
                options.ConfigureMessageHandler = handler => new HttpTracerHandler(handler, loggerWraper, HttpMessageParts.All);

            this.restClient=new RestClient(options);
        }
        /// <summary>
        /// 信用卡授權
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CreatePaymentResult> CreatePaymentAsync(CreatePaymentRequest input)
        {
            var callbackUrl = $"{this.tspgOptions.CallBackUrl}/call-back/{input.PaymentId}";
            var tspgInput = new CreatePaymentParameter(callbackUrl, input);
            RestRequest request = CreateRequest(信用卡授權交易Resource, tspgInput, TransactionType.授權);
            var response = (await this.restClient.PostAsync<Response<CreatePaymentResultParameter>>(request));
            response.Parameters.Validate();

            var result = response.Parameters.ConvertToCreatePaymentResult();

            return result;
        }

        /// <summary>
        /// 查詢交易
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GetPaymentResult> GetPaymentAsync(GetPaymentRequest input)
        {
            var tspgInput = new OtherPaymentParameter(input);

            RestRequest request = CreateRequest(其他交易Resource, tspgInput, TransactionType.查詢);
            var response = await this.restClient.PostAsync<Response<OtherPaymentResultParameterWithDetail>>(request);
            response.Parameters.Validate();
            var result = response.Parameters.ConvertToGetPaymentResult();

            return result;
        }

        /// <summary>
        /// 取消授權交易
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CancelPaymentResult> CancelPaymentAsync(CancelPaymentRequest input)
        {
            var tspgInput = new OtherPaymentParameter(input);

            RestRequest request = CreateRequest(其他交易Resource, tspgInput, TransactionType.取消授權);
            var response = await this.restClient.PostAsync<Response<OtherPaymentResultParameter>>(request);
            response.Parameters.Validate();

            var result = response.Parameters.ConvertToCancelPaymentResult();

            return result;
        }


        /// <summary>
        /// 退貨交易
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<RefundPaymentResult> RefundPaymentAsync(RefundPaymentRequest input)
        {
            var tspgInput = new OtherPaymentParameter(input);

            RestRequest request = CreateRequest(其他交易Resource, tspgInput, TransactionType.退貨);
            var response = (await this.restClient.PostAsync<Response<OtherPaymentResultParameter>>(request));
            response.Parameters.Validate();
            var result = response.Parameters.ConvertToRefundPaymentResult();
            return result;
        }


        protected RestRequest CreateRequest<T>(string resource, T input, TransactionType txType)
        {
            {
                var request = new RestRequest(resource);

                var body = createBody(input, txType);

                request.AddJsonBody(body);

                return request;
            }

            Request<T> createBody(T input, TransactionType txType)
            {
                return new Request<T>()
                {
                    MerchantId = tspgOptions.MerchantId,
                    PayType = tspgOptions.PayType,
                    Sender = tspgOptions.Sender,
                    TerminalId = tspgOptions.TerminalId,
                    TransactionType = txType,
                    Version = tspgOptions.Version,
                    Parameters = input
                };
            }
        }
    }
}
