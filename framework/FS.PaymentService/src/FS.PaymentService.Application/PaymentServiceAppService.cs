using FS.PaymentService.Localization;
using Volo.Abp.Application.Services;

namespace FS.PaymentService;

public abstract class PaymentServiceAppService : ApplicationService
{
    protected PaymentServiceAppService()
    {
        LocalizationResource = typeof(PaymentServiceResource);
        ObjectMapperContext = typeof(PaymentServiceApplicationModule);
    }
}
