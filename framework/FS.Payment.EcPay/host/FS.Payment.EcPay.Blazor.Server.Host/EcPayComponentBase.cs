using FS.Payment.EcPay.Localization;
using Volo.Abp.AspNetCore.Components;

namespace FS.Payment.EcPay.Blazor.Server.Host;

public abstract class EcPayComponentBase : AbpComponentBase
{
    protected EcPayComponentBase()
    {
        LocalizationResource = typeof(EcPayResource);
    }
}
