using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Payment.Localization;

namespace FS.Payment.Tspg.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class TspgPageModel : AbpPageModel
{
    protected TspgPageModel()
    {
        LocalizationResourceType = typeof(PaymentResource);
        ObjectMapperContext = typeof(TspgWebModule);
    }
}
