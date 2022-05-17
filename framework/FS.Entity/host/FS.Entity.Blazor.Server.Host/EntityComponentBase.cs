using FS.Entity.Localization;
using Volo.Abp.AspNetCore.Components;

namespace FS.Entity.Blazor.Server.Host;

public abstract class EntityComponentBase : AbpComponentBase
{
    protected EntityComponentBase()
    {
        LocalizationResource = typeof(EntityResource);
    }
}
