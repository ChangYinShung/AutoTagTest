using FS.Social.LineNotify.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.Social.LineNotify.Pages;

public abstract class LineNotifyPageModel : AbpPageModel
{
    protected LineNotifyPageModel()
    {
        LocalizationResourceType = typeof(LineNotifyResource);
    }
}
