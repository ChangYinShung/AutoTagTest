using FS.Social.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.Social.Pages;

public abstract class SocialPageModel : AbpPageModel
{
    protected SocialPageModel()
    {
        LocalizationResourceType = typeof(SocialResource);
    }
}
