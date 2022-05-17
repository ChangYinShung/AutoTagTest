using FS.CmsKit.ContentComposites.Localization;
using Volo.Abp.AspNetCore.Components;

namespace FS.CmsKit.ContentComposites.Blazor.Server.Host;

public abstract class ContentCompositesComponentBase : AbpComponentBase
{
    protected ContentCompositesComponentBase()
    {
        LocalizationResource = typeof(ContentCompositesResource);
    }
}
