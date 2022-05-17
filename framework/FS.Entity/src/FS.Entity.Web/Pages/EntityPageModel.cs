using FS.Entity.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.Entity.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class EntityPageModel : AbpPageModel
{
    protected EntityPageModel()
    {
        LocalizationResourceType = typeof(EntityResource);
        ObjectMapperContext = typeof(EntityWebModule);
    }
}
