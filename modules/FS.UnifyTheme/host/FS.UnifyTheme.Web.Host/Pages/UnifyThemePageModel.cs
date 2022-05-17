using FS.UnifyTheme.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.UnifyTheme.Pages
{
    public abstract class UnifyThemePageModel : AbpPageModel
    {
        protected UnifyThemePageModel()
        {
            LocalizationResourceType = typeof(UnifyThemeResource);
        }
    }
}