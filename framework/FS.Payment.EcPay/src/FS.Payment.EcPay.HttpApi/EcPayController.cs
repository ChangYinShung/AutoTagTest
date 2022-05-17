using FS.Payment.EcPay.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FS.Payment.EcPay;

public abstract class EcPayController : AbpControllerBase
{
    protected EcPayController()
    {
        LocalizationResource = typeof(EcPayResource);
    }
}
