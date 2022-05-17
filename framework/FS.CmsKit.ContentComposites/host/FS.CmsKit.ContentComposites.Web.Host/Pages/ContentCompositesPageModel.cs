using FS.CmsKit.ContentComposites.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.CmsKit.ContentComposites.Pages;

public abstract class ContentCompositesPageModel : AbpPageModel
{
    protected ContentCompositesPageModel()
    {
        LocalizationResourceType = typeof(ContentCompositesResource);
    }
}
