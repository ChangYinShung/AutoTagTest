using System;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Payment.Requests;
using FS.Tspg;

namespace FS.Payment.Tspg.Pages.Payment.Tspg;


public class PurchaseParameterListGenerator : IPurchaseParameterListGenerator, ITransientDependency
{
    private readonly HttpClientOptions _options;

    

    public PurchaseParameterListGenerator(
        IOptions<HttpClientOptions> options)
    {
        _options = options.Value;
    }

    public TspgPaymentRequestExtraParameterConfiguration GetExtraParameterConfiguration(
        PaymentRequestWithDetailsDto paymentRequest)
    {
        return GetPaymentRequestExtraPropertyConfiguration(paymentRequest);
    }

    private TspgPaymentRequestExtraParameterConfiguration GetPaymentRequestExtraPropertyConfiguration(
        PaymentRequestWithDetailsDto paymentRequest)
    {
        return null;
        //var configuration = new PayPalPaymentRequestExtraParameterConfiguration
        //{
        //    CurrencyCode = _options.CurrencyCode,
        //    Locale = _options.Locale
        //};

        //if (!paymentRequest.ExtraProperties.ContainsKey(PayPalConsts.GatewayName))
        //{
        //    return configuration;
        //}

        //var json = paymentRequest.ExtraProperties[PayPalConsts.GatewayName].ToString();
        //var overrideConfiguration = Newtonsoft.Json.JsonConvert
        //    .DeserializeObject<PayPalPaymentRequestExtraParameterConfiguration>(json);

        //if (!overrideConfiguration.CurrencyCode.IsNullOrWhiteSpace())
        //{
        //    configuration.CurrencyCode = overrideConfiguration.CurrencyCode;
        //}

        //if (!overrideConfiguration.Locale.IsNullOrWhiteSpace())
        //{
        //    configuration.Locale = overrideConfiguration.Locale;
        //}

        //if (!overrideConfiguration.AdditionalCallbackParameters.IsNullOrEmpty())
        //{
        //    configuration.AdditionalCallbackParameters = overrideConfiguration.AdditionalCallbackParameters;
        //}

        //return configuration;
    }
}
