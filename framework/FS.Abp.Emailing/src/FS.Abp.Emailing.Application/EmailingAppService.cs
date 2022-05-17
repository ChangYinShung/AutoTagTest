using FS.Abp.Emailing.Localization;
using Volo.Abp.Application.Services;

namespace FS.Abp.Emailing;

public abstract class EmailingAppService : ApplicationService
{
    protected EmailingAppService()
    {
        LocalizationResource = typeof(EmailingResource);
        ObjectMapperContext = typeof(EmailingApplicationModule);
    }
}
