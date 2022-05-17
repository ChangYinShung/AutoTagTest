using FS.SocialManagement.Localization;
using Volo.Abp.AspNetCore.Components;

namespace FS.SocialManagement.Blazor.Server.Host;

public abstract class SocialManagementComponentBase : AbpComponentBase
{
    protected SocialManagementComponentBase()
    {
        LocalizationResource = typeof(SocialManagementResource);
    }
}
