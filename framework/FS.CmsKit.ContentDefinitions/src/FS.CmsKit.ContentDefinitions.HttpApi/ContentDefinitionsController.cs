using FS.CmsKit.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FS.CmsKit.ContentDefinitions;

public abstract class ContentDefinitionsController : AbpControllerBase
{
    protected ContentDefinitionsController()
    {
        LocalizationResource = typeof(CmsKitResource);
    }
}
