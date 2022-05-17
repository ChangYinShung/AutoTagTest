using System;
using Microsoft.Extensions.Options;
using Volo.Payment;
using FS.Tspg;

namespace CFTA.Payments.Tspg;

public class TspgPaymentWebOptionsSetup : IConfigureOptions<PaymentWebOptions>
{
    protected HttpClientOptions TspgOptions { get; }
    protected PaymentServiceOptions PaymentServiceOptions { get; }

    public TspgPaymentWebOptionsSetup(
        IOptions<HttpClientOptions> tspgOptions,
        IOptions<PaymentServiceOptions> paymentServiceOptions)
    {
        TspgOptions = tspgOptions.Value;
        PaymentServiceOptions = paymentServiceOptions.Value;
    }

    public void Configure(PaymentWebOptions options)
    {
        if (!this.PaymentServiceOptions.UiEnabled) return;

        options.Gateways.Add(
            new PaymentGatewayWebConfiguration(
                TspgConsts.GatewayName,
                TspgConsts.GatewayDisplayName,
                TspgConsts.PrePaymentUrl,
                isSubscriptionSupported: false,
                options.RootUrl.RemovePostFix("/") + TspgConsts.PostPaymentUrl,
                TspgOptions.Recommended,
                TspgOptions.ExtraInfos
            )
        );
    }
}
