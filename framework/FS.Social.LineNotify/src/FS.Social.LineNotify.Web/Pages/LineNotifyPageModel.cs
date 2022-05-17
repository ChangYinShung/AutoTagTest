using FS.Social.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.Social.LineNotify.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class LineNotifyPageModel : AbpPageModel
{
    protected LineNotifyPageModel()
    {
        LocalizationResourceType = typeof(SocialResource);
        ObjectMapperContext = typeof(LineNotifyWebModule);
    }
}
