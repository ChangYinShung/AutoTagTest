using FS.EntityManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.EntityManagement.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class EntityManagementPageModel : AbpPageModel
{
    protected EntityManagementPageModel()
    {
        LocalizationResourceType = typeof(EntityManagementResource);
        ObjectMapperContext = typeof(EntityManagementWebModule);
    }
}
