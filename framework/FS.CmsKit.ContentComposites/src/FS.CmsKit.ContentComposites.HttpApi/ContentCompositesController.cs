using FS.CmsKit.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FS.CmsKit.ContentComposites;

public abstract class ContentCompositesController : AbpControllerBase
{
    protected ContentCompositesController()
    {
        LocalizationResource = typeof(CmsKitResource);
    }
}
