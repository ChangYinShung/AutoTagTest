using FS.Social.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.Social.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class SocialPageModel : AbpPageModel
{
    protected SocialPageModel()
    {
        LocalizationResourceType = typeof(SocialResource);
        ObjectMapperContext = typeof(SocialWebModule);
    }
}
