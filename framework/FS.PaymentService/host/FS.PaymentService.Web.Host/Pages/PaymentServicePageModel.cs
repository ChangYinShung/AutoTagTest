using FS.PaymentService.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.PaymentService.Pages;

public abstract class PaymentServicePageModel : AbpPageModel
{
    protected PaymentServicePageModel()
    {
        LocalizationResourceType = typeof(PaymentServiceResource);
    }
}
