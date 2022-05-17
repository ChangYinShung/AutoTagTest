using FS.FormManagement.Localization;
using Volo.Abp.AspNetCore.Components;

namespace FS.FormManagement.Blazor.Server.Host;

public abstract class FormManagementComponentBase : AbpComponentBase
{
    protected FormManagementComponentBase()
    {
        LocalizationResource = typeof(FormManagementResource);
    }
}
