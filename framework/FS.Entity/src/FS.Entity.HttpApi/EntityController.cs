using FS.Entity.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FS.Entity;

public abstract class EntityController : AbpControllerBase
{
    protected EntityController()
    {
        LocalizationResource = typeof(EntityResource);
    }
}
