using FS.EShopManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.EShopManagement.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class EShopManagementPageModel : AbpPageModel
{
    protected EShopManagementPageModel()
    {
        LocalizationResourceType = typeof(EShopManagementResource);
        ObjectMapperContext = typeof(EShopManagementWebModule);
    }
}
