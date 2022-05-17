using FS.EShopManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.EShopManagement.Pages;

public abstract class EShopManagementPageModel : AbpPageModel
{
    protected EShopManagementPageModel()
    {
        LocalizationResourceType = typeof(EShopManagementResource);
    }
}
