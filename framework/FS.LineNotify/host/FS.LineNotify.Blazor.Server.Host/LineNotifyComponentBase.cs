using FS.LineNotify.Localization;
using Volo.Abp.AspNetCore.Components;

namespace FS.LineNotify.Blazor.Server.Host;

public abstract class LineNotifyComponentBase : AbpComponentBase
{
    protected LineNotifyComponentBase()
    {
        LocalizationResource = typeof(LineNotifyResource);
    }
}
