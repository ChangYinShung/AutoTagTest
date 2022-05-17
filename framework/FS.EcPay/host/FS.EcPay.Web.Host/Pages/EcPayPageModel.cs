using FS.EcPay.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.EcPay.Pages;

public abstract class EcPayPageModel : AbpPageModel
{
    protected EcPayPageModel()
    {
        LocalizationResourceType = typeof(EcPayResource);
    }
}
