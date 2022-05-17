using FS.UnifyTheme.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.UnifyTheme.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class UnifyThemePageModel : AbpPageModel
    {
        protected UnifyThemePageModel()
        {
            LocalizationResourceType = typeof(UnifyThemeResource);
            ObjectMapperContext = typeof(UnifyThemeWebModule);
        }
    }
}