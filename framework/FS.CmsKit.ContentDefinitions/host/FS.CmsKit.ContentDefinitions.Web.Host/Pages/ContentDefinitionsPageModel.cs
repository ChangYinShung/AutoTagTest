using FS.CmsKit.ContentDefinitions.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.CmsKit.ContentDefinitions.Pages;

public abstract class ContentDefinitionsPageModel : AbpPageModel
{
    protected ContentDefinitionsPageModel()
    {
        LocalizationResourceType = typeof(ContentDefinitionsResource);
    }
}
