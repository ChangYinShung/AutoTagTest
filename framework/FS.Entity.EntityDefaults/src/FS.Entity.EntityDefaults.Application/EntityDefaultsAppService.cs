using FS.Entity.Localization;
using Volo.Abp.Application.Services;

namespace FS.Entity.EntityDefaults
{
    public abstract class EntityDefaultsAppService : ApplicationService
    {
        protected EntityDefaultsAppService()
        {
            LocalizationResource = typeof(EntityResource);
            ObjectMapperContext = typeof(EntityDefaultsApplicationModule);
        }
    }
}


