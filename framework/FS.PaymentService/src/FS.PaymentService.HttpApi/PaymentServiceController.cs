using FS.PaymentService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FS.PaymentService;

public abstract class PaymentServiceController : AbpControllerBase
{
    protected PaymentServiceController()
    {
        LocalizationResource = typeof(PaymentServiceResource);
    }
}
