using FS.CmsKit.Localization;
using Volo.Abp.Application.Services;

namespace FS.CmsKit.ContentComposites;

public abstract class ContentCompositesAppService : ApplicationService
{
    protected ContentCompositesAppService()
    {
        LocalizationResource = typeof(CmsKitResource);
        ObjectMapperContext = typeof(ContentCompositesApplicationModule);
    }
}
