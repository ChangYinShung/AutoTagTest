using FS.Tspg.Localization;
using Volo.Abp.Application.Services;

namespace FS.Tspg;

public abstract class TspgAppService : ApplicationService
{
    protected TspgAppService()
    {
        LocalizationResource = typeof(TspgResource);
        ObjectMapperContext = typeof(TspgApplicationModule);
    }
}
