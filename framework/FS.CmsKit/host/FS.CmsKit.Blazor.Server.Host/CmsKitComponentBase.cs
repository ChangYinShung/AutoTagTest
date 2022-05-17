using FS.CmsKit.Localization;
using Volo.Abp.AspNetCore.Components;

namespace FS.CmsKit.Blazor.Server.Host;

public abstract class CmsKitComponentBase : AbpComponentBase
{
    protected CmsKitComponentBase()
    {
        LocalizationResource = typeof(CmsKitResource);
    }
}
