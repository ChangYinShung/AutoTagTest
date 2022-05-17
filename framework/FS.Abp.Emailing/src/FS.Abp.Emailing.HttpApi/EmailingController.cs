using FS.Abp.Emailing.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FS.Abp.Emailing;

public abstract class EmailingController : AbpControllerBase
{
    protected EmailingController()
    {
        LocalizationResource = typeof(EmailingResource);
    }
}
