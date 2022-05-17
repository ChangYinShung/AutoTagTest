using FS.CmsKit.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.CmsKit.Pages;

public abstract class CmsKitPageModel : AbpPageModel
{
    protected CmsKitPageModel()
    {
        LocalizationResourceType = typeof(CmsKitResource);
    }
}
