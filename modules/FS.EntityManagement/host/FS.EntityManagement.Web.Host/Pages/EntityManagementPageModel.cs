using FS.EntityManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.EntityManagement.Pages;

public abstract class EntityManagementPageModel : AbpPageModel
{
    protected EntityManagementPageModel()
    {
        LocalizationResourceType = typeof(EntityManagementResource);
    }
}
