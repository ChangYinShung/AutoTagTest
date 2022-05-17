using FS.Tspg.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.Tspg.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class TspgPageModel : AbpPageModel
{
    protected TspgPageModel()
    {
        LocalizationResourceType = typeof(TspgResource);
        ObjectMapperContext = typeof(TspgWebModule);
    }
}
