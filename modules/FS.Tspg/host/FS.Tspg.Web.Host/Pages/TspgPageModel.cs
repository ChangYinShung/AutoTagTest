using FS.Tspg.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.Tspg.Pages;

public abstract class TspgPageModel : AbpPageModel
{
    protected TspgPageModel()
    {
        LocalizationResourceType = typeof(TspgResource);
    }
}
