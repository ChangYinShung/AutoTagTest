using System;
using FS.EcPay;
using Microsoft.Extensions.Options;
using Volo.Payment;

namespace CFTA.Payments.EcPay;

public class EcPayPaymentWebOptionsSetup : IConfigureOptions<PaymentWebOptions>
{
    protected HttpClientOptions EcPayOptions { get; }
    protected PaymentServiceOptions PaymentServiceOptions { get; }

    public EcPayPaymentWebOptionsSetup(
        IOptions<HttpClientOptions> ecPayOptions,
        IOptions<PaymentServiceOptions> paymentServiceOptions)
    {
        EcPayOptions = ecPayOptions.Value;
        PaymentServiceOptions = paymentServiceOptions.Value;
    }

    public void Configure(PaymentWebOptions options)
    {
        if (!this.PaymentServiceOptions.UiEnabled) return;

        options.Gateways.Add(
            new PaymentGatewayWebConfiguration(
                EcPayConsts.GatewayName,
                EcPayConsts.GatewayDisplayName,
                EcPayConsts.PrePaymentUrl,
                isSubscriptionSupported: false,
                options.RootUrl.RemovePostFix("/") + EcPayConsts.PostPaymentUrl
                //EcPayOptions.Recommended,
                //EcPayOptions.ExtraInfos
            )
        );
    }
}
