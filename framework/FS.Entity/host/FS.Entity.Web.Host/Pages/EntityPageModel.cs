using FS.Entity.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.Entity.Pages;

public abstract class EntityPageModel : AbpPageModel
{
    protected EntityPageModel()
    {
        LocalizationResourceType = typeof(EntityResource);
    }
}
