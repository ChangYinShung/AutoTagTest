using FS.CmsKit.ContentDefinitions.Localization;
using Volo.Abp.AspNetCore.Components;

namespace FS.CmsKit.ContentDefinitions.Blazor.Server.Host;

public abstract class ContentDefinitionsComponentBase : AbpComponentBase
{
    protected ContentDefinitionsComponentBase()
    {
        LocalizationResource = typeof(ContentDefinitionsResource);
    }
}
