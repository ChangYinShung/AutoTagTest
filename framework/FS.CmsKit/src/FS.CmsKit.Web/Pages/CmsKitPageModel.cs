using FS.CmsKit.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.CmsKit.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class CmsKitPageModel : AbpPageModel
{
    protected CmsKitPageModel()
    {
        LocalizationResourceType = typeof(CmsKitResource);
        ObjectMapperContext = typeof(CmsKitWebModule);
    }
}
