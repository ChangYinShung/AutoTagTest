using FS.SocialManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.SocialManagement.Pages;

public abstract class SocialManagementPageModel : AbpPageModel
{
    protected SocialManagementPageModel()
    {
        LocalizationResourceType = typeof(SocialManagementResource);
    }
}
