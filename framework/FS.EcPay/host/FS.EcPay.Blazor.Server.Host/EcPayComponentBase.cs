using FS.EcPay.Localization;
using Volo.Abp.AspNetCore.Components;

namespace FS.EcPay.Blazor.Server.Host;

public abstract class EcPayComponentBase : AbpComponentBase
{
    protected EcPayComponentBase()
    {
        LocalizationResource = typeof(EcPayResource);
    }
}
