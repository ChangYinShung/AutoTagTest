using FS.Abp.Emailing.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.Abp.Emailing.Pages;

public abstract class EmailingPageModel : AbpPageModel
{
    protected EmailingPageModel()
    {
        LocalizationResourceType = typeof(EmailingResource);
    }
}
