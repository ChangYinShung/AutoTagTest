using FS.PaymentService.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.PaymentService.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class PaymentServicePageModel : AbpPageModel
{
    protected PaymentServicePageModel()
    {
        //LocalizationResourceType = typeof(PaymentServiceResource);
        //ObjectMapperContext = typeof(PaymentServiceWebModule);
    }
}
