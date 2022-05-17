using FS.PaymentService.Localization;
using Volo.Abp.AspNetCore.Components;

namespace FS.PaymentService.Blazor.Server.Host;

public abstract class PaymentServiceComponentBase : AbpComponentBase
{
    protected PaymentServiceComponentBase()
    {
        LocalizationResource = typeof(PaymentServiceResource);
    }
}
