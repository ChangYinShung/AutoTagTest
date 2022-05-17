using FS.EntityManagement.Localization;
using Volo.Abp.AspNetCore.Components;

namespace FS.EntityManagement.Blazor.Server.Host;

public abstract class EntityManagementComponentBase : AbpComponentBase
{
    protected EntityManagementComponentBase()
    {
        LocalizationResource = typeof(EntityManagementResource);
    }
}
