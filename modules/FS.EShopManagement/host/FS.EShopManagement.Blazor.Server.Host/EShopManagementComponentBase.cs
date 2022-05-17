using FS.EShopManagement.Localization;
using Volo.Abp.AspNetCore.Components;

namespace FS.EShopManagement.Blazor.Server.Host;

public abstract class EShopManagementComponentBase : AbpComponentBase
{
    protected EShopManagementComponentBase()
    {
        LocalizationResource = typeof(EShopManagementResource);
    }
}
