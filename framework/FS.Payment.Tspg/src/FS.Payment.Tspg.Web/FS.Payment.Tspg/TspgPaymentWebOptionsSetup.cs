using System;
using Microsoft.Extensions.Options;
using Volo.Payment;
using FS.Tspg;

namespace FS.Payment.Tspg;

public class TspgPaymentWebOptionsSetup : IConfigureOptions<PaymentWebOptions>
{
    protected HttpClientOptions TspgOptions { get; }

    public TspgPaymentWebOptionsSetup(IOptions<HttpClientOptions> tspgOptions)
    {
        TspgOptions = tspgOptions.Value;
    }

    public void Configure(PaymentWebOptions options)
    {
        options.Gateways.Add(
            new PaymentGatewayWebConfiguration(
                TspgConsts.GatewayName,
                TspgConsts.PrePaymentUrl,
                isSubscriptionSupported: false,
                options.RootUrl.RemovePostFix("/") + TspgConsts.PostPaymentUrl,
                TspgOptions.Recommended,
                TspgOptions.ExtraInfos
            )
        );
    }
}
