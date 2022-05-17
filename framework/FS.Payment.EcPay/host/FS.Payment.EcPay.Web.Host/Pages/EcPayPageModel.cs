using FS.Payment.EcPay.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.Payment.EcPay.Pages;

public abstract class EcPayPageModel : AbpPageModel
{
    protected EcPayPageModel()
    {
        LocalizationResourceType = typeof(EcPayResource);
    }
}
