using Volo.Abp.AspNetCore.Mvc;
using Volo.Payment.Localization;

namespace FS.Payment.Tspg;

public abstract class TspgController : AbpControllerBase
{
    protected TspgController()
    {
        LocalizationResource = typeof(PaymentResource);
    }
}
