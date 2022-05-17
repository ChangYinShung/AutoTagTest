using FS.CmsKit.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FS.CmsKit;

public abstract class CmsKitController : AbpControllerBase
{
    protected CmsKitController()
    {
        LocalizationResource = typeof(CmsKitResource);
    }
}
