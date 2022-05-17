using FS.Social.LineNotify.Localization;
using Volo.Abp.AspNetCore.Components;

namespace FS.Social.LineNotify.Blazor.Server.Host;

public abstract class LineNotifyComponentBase : AbpComponentBase
{
    protected LineNotifyComponentBase()
    {
        LocalizationResource = typeof(LineNotifyResource);
    }
}
