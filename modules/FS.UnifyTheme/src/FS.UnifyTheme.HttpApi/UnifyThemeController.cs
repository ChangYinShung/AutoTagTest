using FS.UnifyTheme.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FS.UnifyTheme
{
    public abstract class UnifyThemeController : AbpController
    {
        protected UnifyThemeController()
        {
            LocalizationResource = typeof(UnifyThemeResource);
        }
    }
}
