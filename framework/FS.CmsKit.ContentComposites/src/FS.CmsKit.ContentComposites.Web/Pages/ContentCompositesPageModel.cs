using FS.CmsKit.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.CmsKit.ContentComposites.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class ContentCompositesPageModel : AbpPageModel
{
    protected ContentCompositesPageModel()
    {
        LocalizationResourceType = typeof(CmsKitResource);
        ObjectMapperContext = typeof(ContentCompositesWebModule);
    }
}
