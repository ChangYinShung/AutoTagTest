using FS.Abp.Emailing.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.Abp.Emailing.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class EmailingPageModel : AbpPageModel
{
    protected EmailingPageModel()
    {
        LocalizationResourceType = typeof(EmailingResource);
        ObjectMapperContext = typeof(EmailingWebModule);
    }
}
