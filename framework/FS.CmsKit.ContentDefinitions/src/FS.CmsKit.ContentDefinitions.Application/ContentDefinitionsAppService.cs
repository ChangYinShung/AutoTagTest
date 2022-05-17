using FS.CmsKit.Localization;
using Volo.Abp.Application.Services;

namespace FS.CmsKit.ContentDefinitions;

public abstract class ContentDefinitionsAppService : ApplicationService
{
    protected ContentDefinitionsAppService()
    {
        LocalizationResource = typeof(CmsKitResource);
        ObjectMapperContext = typeof(ContentDefinitionsApplicationModule);
    }
}
