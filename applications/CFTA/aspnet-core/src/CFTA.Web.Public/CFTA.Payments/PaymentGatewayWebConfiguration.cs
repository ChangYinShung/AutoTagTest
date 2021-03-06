using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp;

namespace Volo.Payment;

public class PaymentGatewayWebConfiguration
{
    [NotNull]
    public string Name { get; }

    [NotNull]
    public string DisplayName { get; }

    [NotNull]
    public string PrePaymentUrl { get; }

    public string PostPaymentUrl { get; }

    /// <summary>
    /// Default value: 1000.
    /// </summary>
    public int Order { get; set; } = 1000;

    public bool Recommended { get; set; }

    public List<string> ExtraInfos { get; set; }

    public PaymentGatewayWebConfiguration(
        [NotNull] string name,
        [NotNull] string displayName,
        [NotNull] string prePaymentUrl,
        bool isSubscriptionSupported,
        string postPaymentUrl,
        bool recommended = false,
        List<string> extraInfos = null)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        DisplayName = Check.NotNullOrWhiteSpace(displayName, nameof(displayName)); ;
        PrePaymentUrl = Check.NotNull(prePaymentUrl, nameof(prePaymentUrl));
        PostPaymentUrl = postPaymentUrl;
        Recommended = recommended;
        ExtraInfos = extraInfos ?? new List<string>();
    }
}
