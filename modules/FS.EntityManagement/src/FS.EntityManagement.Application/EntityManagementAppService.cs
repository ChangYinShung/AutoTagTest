using FS.Entity.Localization;
using Volo.Abp.Application.Services;

namespace FS.EntityManagement
{
    public abstract class EntityManagementAppService : ApplicationService
    {
        protected EntityManagementAppService()
        {
            LocalizationResource = typeof(EntityResource);
            ObjectMapperContext = typeof(EntityManagementApplicationModule);
        }
    }
}


