using FS.Social.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.SocialManagement.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class SocialManagementPageModel : AbpPageModel
{
    protected SocialManagementPageModel()
    {
        LocalizationResourceType = typeof(SocialResource);
        ObjectMapperContext = typeof(SocialManagementWebModule);
    }
}
