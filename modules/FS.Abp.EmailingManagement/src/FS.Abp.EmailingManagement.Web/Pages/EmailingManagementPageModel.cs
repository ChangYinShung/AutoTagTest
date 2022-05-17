using FS.Abp.EmailingManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.Abp.EmailingManagement.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class EmailingManagementPageModel : AbpPageModel
{
    protected EmailingManagementPageModel()
    {
        LocalizationResourceType = typeof(EmailingManagementResource);
        ObjectMapperContext = typeof(EmailingManagementWebModule);
    }
}
