using FS.Abp.EmailingManagement.Localization;
using Volo.Abp.AspNetCore.Components;

namespace FS.Abp.EmailingManagement.Blazor.Server.Host;

public abstract class EmailingManagementComponentBase : AbpComponentBase
{
    protected EmailingManagementComponentBase()
    {
        LocalizationResource = typeof(EmailingManagementResource);
    }
}
