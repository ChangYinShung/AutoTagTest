using FS.Payment.EcPay.Localization;
using Volo.Abp.Application.Services;

namespace FS.Payment.EcPay;

public abstract class EcPayAppService : ApplicationService
{
    protected EcPayAppService()
    {
        LocalizationResource = typeof(EcPayResource);
        ObjectMapperContext = typeof(EcPayApplicationModule);
    }
}
