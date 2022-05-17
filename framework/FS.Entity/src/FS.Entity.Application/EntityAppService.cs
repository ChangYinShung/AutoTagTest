using FS.Entity.Localization;
using Volo.Abp.Application.Services;

namespace FS.Entity;

public abstract class EntityAppService : ApplicationService
{
    protected EntityAppService()
    {
        LocalizationResource = typeof(EntityResource);
        ObjectMapperContext = typeof(EntityApplicationModule);
    }
}
