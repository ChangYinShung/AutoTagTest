using FS.CmsKit.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.CmsKit.ContentDefinitions.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class ContentDefinitionsPageModel : AbpPageModel
{
    protected ContentDefinitionsPageModel()
    {
        LocalizationResourceType = typeof(CmsKitResource);
        ObjectMapperContext = typeof(ContentDefinitionsWebModule);
    }
}
