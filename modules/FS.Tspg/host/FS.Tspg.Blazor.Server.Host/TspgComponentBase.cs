using FS.Tspg.Localization;
using Volo.Abp.AspNetCore.Components;

namespace FS.Tspg.Blazor.Server.Host;

public abstract class TspgComponentBase : AbpComponentBase
{
    protected TspgComponentBase()
    {
        LocalizationResource = typeof(TspgResource);
    }
}
