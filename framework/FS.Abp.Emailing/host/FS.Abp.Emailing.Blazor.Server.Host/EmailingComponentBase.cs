using FS.Abp.Emailing.Localization;
using Volo.Abp.AspNetCore.Components;

namespace FS.Abp.Emailing.Blazor.Server.Host;

public abstract class EmailingComponentBase : AbpComponentBase
{
    protected EmailingComponentBase()
    {
        LocalizationResource = typeof(EmailingResource);
    }
}
