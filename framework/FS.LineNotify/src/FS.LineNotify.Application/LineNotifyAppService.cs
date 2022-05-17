using FS.LineNotify.Localization;
using Volo.Abp.Application.Services;

namespace FS.LineNotify;

public abstract class LineNotifyAppService : ApplicationService
{
    protected LineNotifyAppService()
    {
        LocalizationResource = typeof(LineNotifyResource);
        ObjectMapperContext = typeof(LineNotifyApplicationModule);
    }
}
