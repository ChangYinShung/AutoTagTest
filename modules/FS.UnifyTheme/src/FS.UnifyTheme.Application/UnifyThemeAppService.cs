using FS.UnifyTheme.Localization;
using Volo.Abp.Application.Services;

namespace FS.UnifyTheme
{
    public abstract class UnifyThemeAppService : ApplicationService
    {
        protected UnifyThemeAppService()
        {
            LocalizationResource = typeof(UnifyThemeResource);
            ObjectMapperContext = typeof(UnifyThemeApplicationModule);
        }
    }
}
