//using FS.Payment.EcPay.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.Payment.EcPay.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class EcPayPageModel : AbpPageModel
{
    protected EcPayPageModel()
    {
        //LocalizationResourceType = typeof(EcPayResource);
        ObjectMapperContext = typeof(EcPayWebModule);
    }
}
