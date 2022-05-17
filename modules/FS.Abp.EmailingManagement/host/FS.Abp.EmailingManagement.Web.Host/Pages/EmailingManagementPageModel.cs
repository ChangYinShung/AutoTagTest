using FS.Abp.EmailingManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.Abp.EmailingManagement.Pages;

public abstract class EmailingManagementPageModel : AbpPageModel
{
    protected EmailingManagementPageModel()
    {
        LocalizationResourceType = typeof(EmailingManagementResource);
    }
}
