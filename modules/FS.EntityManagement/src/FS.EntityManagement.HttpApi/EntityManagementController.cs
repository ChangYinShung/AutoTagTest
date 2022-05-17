using FS.Entity.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FS.EntityManagement
{
    public abstract class EntityManagementController : AbpControllerBase
    {
        protected EntityManagementController()
        {
            LocalizationResource = typeof(EntityResource);
        }
    }
}


