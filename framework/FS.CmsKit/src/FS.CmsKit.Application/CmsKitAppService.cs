using FS.CmsKit.Localization;
using Volo.Abp.Application.Services;

namespace FS.CmsKit;

public abstract class CmsKitAppService : ApplicationService
{
    protected CmsKitAppService()
    {
        LocalizationResource = typeof(CmsKitResource);
        ObjectMapperContext = typeof(CmsKitApplicationModule);
    }
}
